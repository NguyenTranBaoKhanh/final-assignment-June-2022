import React, { useEffect, useState } from "react";
import { Search } from "react-feather";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { getAssets } from "../reducer";
import AssetTableSelect from "./AssetTableSelect";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import ISelectOption from "src/interfaces/ISelectOption";
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
    DEFAULT_ASSET_SORT_COLUMN_NAME,
} from "src/constants/paging"
import { getLocalStorage } from "src/utils/localStorage";

type Props = {
    handleSelectAsset: Function;
    code: String
};

const AssetSelect: React.FC<Props> = ({
    handleSelectAsset, code
}) => {
    const dispatch = useAppDispatch();
    const { assets, loading } = useAppSelector((state) => state.assetReducer);
    // const { account } = useAppSelector(state => state.authReducer);
    // const { assetResult } = useAppSelector(state => state.assetReducer)
    
    const [query, setQuery] = useState({
        page: assets?.items ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        Ascending: ACCSENDING,
        sortBy: DEFAULT_ASSET_SORT_COLUMN_NAME,
        locationId: getLocalStorage('locationID'),
        assetState: [1]
    } as IQueryAssetModel);

    

    const [keyword, setSearch] = useState("");

    const handleChangeSearch = (e) => {
        e.preventDefault();

        const search = e.target.value;
        setSearch(search);
    };

    const handleSelect = (data) => {
        handleSelectAsset(data)
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
            <div>
                <div className="d-flex intro-x">
                    <div className="d-flex align-items-center w-ld ml-auto search-input">
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
                </div>

                <AssetTableSelect
                    assets={assets}
                    handlePage={handlePage}
                    handleSort={handleSort}
                    sortState={{
                        columnValue: query.sortBy,
                        orderBy: query.Ascending,
                    }}
                    code={code}
                    fetchData={fetchData}
                    handleSelect={handleSelect}
                />
            </div>
        </>
    )
}

export default AssetSelect;