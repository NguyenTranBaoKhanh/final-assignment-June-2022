import React, { useEffect, useState } from "react";
import { CalendarDateFill, FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";
import { useLocation } from 'react-router-dom';
import DatePicker from 'react-datepicker';
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { getRequests } from "../reducer";
import { Link } from "react-router-dom";
import RequestTable from "./RequestTable";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import ISelectOption from "src/interfaces/ISelectOption";
import { FilterRequestStatesOptions } from "src/constants/selectOptions";
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
    DEFAULT_REQUEST_SORT_COLUMN_NAME,
} from "src/constants/paging"
import { getLocalStorage } from "src/utils/localStorage";
import IQueryRequestModel from "src/interfaces/Request/IQueryRequestModel";


const ListRequest = () => {
    const dispatch = useAppDispatch();
    const { requests, loading } = useAppSelector((state) => state.requestReducer);
    const { account } = useAppSelector(state => state.authReducer);
    const { requestResult } = useAppSelector(state => state.requestReducer)

    const [query, setQuery] = useState({
        page: requests?.items ?? 1,
        limit: DEFAULT_PAGE_LIMIT,
        Ascending: ACCSENDING,
        sortBy: DEFAULT_REQUEST_SORT_COLUMN_NAME,
        locationId: getLocalStorage('locationID'),
    } as IQueryRequestModel);

    const output = JSON.parse(JSON.stringify(requests))
    if (requestResult && (query.page == 1 || typeof (query.page) == 'object')) {
        const assetResultClone = { ...requestResult }
        output.items.reverse()
        output.items.push(assetResultClone)
        output.items.reverse()
        console.log('output', output)
    }

    const [keyword, setSearch] = useState("");

    //handleState
    const [selectedType, setSelectedType] = useState([
        { id: 1, label: 'All', value: 0 },
    ] as ISelectOption[]);

    const handleState = (selected: ISelectOption[]) => {
        if (selected.length === 0) {
            setQuery({
                ...query,
                State: [],
            });

            setSelectedType([FilterRequestStatesOptions[0]]);
            return;
        }

        const selectedAll = selected.find((item) => item.id === 1);

        setSelectedType((prevSelected) => {
            if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
                setQuery({
                    ...query,
                    State: [],
                });

                return [selectedAll];
            }

            const newSelected = selected.filter((item) => item.id !== 1);
            const State = newSelected.map((item) => item.value as number);

            setQuery({
                ...query,
                State,
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

    const [startDate, setStartDate] = useState(new Date());
    const handleDate = (date: Date) => {
        const assignedDate = new Date(date).getDate();
        const assignedMonth = new Date(date).getMonth() + 1;
        const assignedYear = new Date(date).getFullYear();
        const fullDate = assignedMonth + "/" + assignedDate + "/" + assignedYear;
        const assignDate = fullDate;
        setStartDate(new Date(fullDate))
        setQuery({
            ...query,
            assignDate,
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
        dispatch(getRequests(query));
    }

    useEffect(() => {
        fetchData();

    }, [query]);

    return (
        <>
            <div className="primaryColor text-title intro-x">Request List</div>
            <div>
                <div className="d-flex mb-5 intro-x">
                    <div className="d-flex align-items-center w-md mr-5">
                        <ReactMultiSelectCheckboxes
                            options={FilterRequestStatesOptions}
                            hideSearch={true}
                            placeholderButtonLabel="State"
                            value={selectedType}
                            onChange={handleState}
                        />
                        <div className="border p-2">
                            <FunnelFill />
                        </div>
                    </div>

                    <div className="list__assignment d-flex align-items-center w-md mr-5" style={{ position: 'relative' }}>
                        <DatePicker className="border p-2" dateFormat='dd/MM/yyyy' selected={startDate} onChange={handleDate} />
                        <div className="border p-2 align-items-center">
                            <CalendarDateFill className="calendar__date__fill"/>
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
                </div>

                <RequestTable
                    requests={requestResult ? requests : output}
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

export default ListRequest;