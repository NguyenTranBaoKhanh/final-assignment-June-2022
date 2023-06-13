import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";
import { useLocation } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { getAssets } from "../reducer";
import { Link } from "react-router-dom";
import AssetTable from "./AssetTable";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import ISelectOption from "src/interfaces/ISelectOption";
import { FilterAssetStatesOptions, FilterAssetCategoriesOptions } from "src/constants/selectOptions";
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
    DEFAULT_ASSET_SORT_COLUMN_NAME,
} from "src/constants/paging"
import { getLocalStorage } from "src/utils/localStorage";

const Edit = () => {
    const dispatch = useAppDispatch();
    const { assets, loading } = useAppSelector((state) => state.assetReducer);
    console.log('assets', assets)
    const { account } = useAppSelector(state => state.authReducer);
    const { assetResult } = useAppSelector(state => state.assetReducer)
    
    const [query, setQuery] = useState({
        page: assets?.items ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        Ascending: ACCSENDING,
        sortBy: DEFAULT_ASSET_SORT_COLUMN_NAME,
        // locationId: account?.location ?? null
        locationId: getLocalStorage('locationID'),
        assetState: [1, 2, 5]

    } as IQueryAssetModel);


    const output = JSON.parse(JSON.stringify(assets))
    if (assetResult && (query.page == 1 || typeof (query.page) == 'object')) {
        const assetResultClone = {...assetResult}
        assetResultClone.categoryName = "Laptop";
        output.items.reverse()
        output.items.push(assetResultClone)
        output.items.reverse()
        console.log('output', output)
    }

    const [keyword, setSearch] = useState("");

    //handleState
    const [selectedType, setSelectedType] = useState([
        { id: 2, label: 'Available', value: 1 },
        { id: 3, label: 'Assigned', value: 2 },
        { id: 6, label: 'Not Available', value: 5 },
    ] as ISelectOption[]);

    const handleState = (selected: ISelectOption[]) => {
        if (selected.length === 0) {
            setQuery({
                ...query,
                assetState: [],
            });

            setSelectedType([FilterAssetStatesOptions[0]]);
            return;
        }

        const selectedAll = selected.find((item) => item.id === 1);

        setSelectedType((prevSelected) => {
            if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
                setQuery({
                    ...query,
                    assetState: [],
                });

                return [selectedAll];
            }

            const newSelected = selected.filter((item) => item.id !== 1);
            const assetState = newSelected.map((item) => item.value as number);

            setQuery({
                ...query,
                assetState,
            });

            return newSelected;
        });
    };

    //handleCategory
    const [selectedCategoty, setSelectedCategoty] = useState([
        { id: 1, label: "Category", value: 0 },
    ] as ISelectOption[]);

    const handleCategory = (selected: ISelectOption[]) => {
        if (selected.length === 0) {
            setQuery({
                ...query,
                category: [],
            });

            setSelectedCategoty([FilterAssetCategoriesOptions[0]]);
            return;
        }

        const selectedAll = selected.find((item) => item.id === 1);

        setSelectedCategoty((prevSelected) => {
            if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
                setQuery({
                    ...query,
                    category: [],
                });

                return [selectedAll];
            }

            const newSelected = selected.filter((item) => item.id !== 1);
            const category = newSelected.map((item) => item.value as string);

            setQuery({
                ...query,
                category,
            });

            return newSelected;
        });
    };

    const handleChangeSearch = (e) => {
        e.preventDefault();

        const search = e.target.value;
        setSearch(search);
    };

    const handlePage = (page: number) => {
        setQuery({
            ...query,
            page,
        });
    };

    const handleSearch = () => {
        setQuery({
            ...query,
            keyword,
        });
    };

    const handleSort = (sortBy: string) => {
        const Ascending = query.Ascending === ACCSENDING ? DECSENDING : ACCSENDING;

        setQuery({
            ...query,
            sortBy,
            Ascending,
        });
    };

    const fetchData = () => {
        dispatch(getAssets(query));
    }

    useEffect(() => {
        fetchData();

    }, [query]);
    return (
        <>
            <div className="primaryColor text-title intro-x">Asset List</div>
            <div>
                <div className="d-flex mb-5 intro-x">
                    <div className="d-flex align-items-center w-md mr-5">
                        <ReactMultiSelectCheckboxes
                            options={FilterAssetStatesOptions}
                            hideSearch={true}
                            placeholderButtonLabel="State"
                            value={selectedType}
                            onChange={handleState}
                        />
                        <div className="border p-2">
                            <FunnelFill />
                        </div>
                    </div>

                    <div className="d-flex align-items-center w-md mr-5">
                        <ReactMultiSelectCheckboxes
                            options={FilterAssetCategoriesOptions}
                            hideSearch={true}
                            placeholderButtonLabel="Category"
                            value={selectedCategoty}
                            onChange={handleCategory}
                        />
                        <div className="border p-2">
                            <FunnelFill />
                        </div>
                    </div>

                    <div className="d-flex align-items-center w-ld ml-auto">
                        <div className="input-group">
                            <input
                                onChange={handleChangeSearch}
                                value={keyword}
                                type="text"
                                className="form-control"
                            />
                            <span onClick={handleSearch} className="border p-2 pointer">
                                <Search />
                            </span>
                        </div>
                    </div>

                    <div className="d-flex align-items-center ml-3">
                        <Link to="/asset/edit" type="button" className="btn btn-danger">
                            Edit Asset
                        </Link>
                    </div>
                </div>

                <AssetTable
                    assets={!assetResult ? assets : output}
                    handlePage={handlePage}
                    handleSort={handleSort}
                    sortState={{
                        columnValue: query.sortBy,
                        orderBy: query.Ascending,
                    }}
                    fetchData={fetchData}
                />
            </div>
        </>
    )
}

export default Edit;