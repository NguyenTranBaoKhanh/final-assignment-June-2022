import React, { useState } from "react";
import { ArrowCounterclockwise, CheckLg, PencilFill, XCircle, XLg } from "react-bootstrap-icons";
import { useNavigate } from "react-router-dom";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";
import Table, { SortType } from "src/components/Table";
import Info from "src/containers/Assignment/Info";
import { useAppDispatch } from "src/hooks/redux";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import { acceptAssignment, declineAssignment, updateUserAssignment } from "../reducer";
import ConfirmModal from "src/components/ConfirmModal";


const columns: IColumnOption[] = [
    { columnName: "Asset Code", columnValue: "AssetCode" },
    { columnName: "Asset Name", columnValue: "AssetName" },
    { columnName: "Category", columnValue: "Category" },
    { columnName: "Assigned Date", columnValue: "AssignedDate" },
    { columnName: "State", columnValue: "assignmentState" },
];

type Props = {
    assignments: IPagedModel<IAssignment> | null;
    handlePage: (page: number) => void;
    handleSort: (colValue: string) => void;
    sortState: SortType;
    fetchData: Function;
};

const UserAssignmentTable: React.FC<Props> = ({ assignments, handlePage, handleSort, sortState, fetchData }) => {

    const navigate = useNavigate();
    const dispatch = useAppDispatch()
    const [showDetail, setShowDetail] = useState(false);
    const [assignmentDetail, setAssignmentDetail] = useState(null as IAssignment | null);
    const [disableState, setDisable] = useState({
        isOpen: false,
        id: 0,
        title: "",
        message: "",
        isDisable: true,
    });

    const handleCloseDetail = () => {
        setShowDetail(false);
    };

    const showState = (state: string | undefined) => {
        if (state === "WaitingReturn") {
            state = "Waiting for retunring";
        }
        else if (state === "Waiting") {
            state = "Waiting for acceptance";
        }
        return state;
    }

    const handleShowInfo = (id: number | undefined) => {
        const assignment = assignments?.items.find((item) => item.id === id);
        if (assignment) {
            setAssignmentDetail(assignment);
            setShowDetail(true);
        }
    };

    const [action, setAction] = useState("");

    const handleShowAccept = async (id: number) => {
        setDisable({
            id,
            isOpen: true,
            title: "Are you sure?",
            message: "Do you want to accept this assignment?",
            isDisable: true,
         });
         setAction("accept")
    }

    const handleConfirmAccept = () => {
        dispatch(
            acceptAssignment({
               handleResult,
               assignmentId: disableState.id,
            })
         );
    }

    const handleShowDecline = async (id: number) => {
        setDisable({
            id,
            isOpen: true,
            title: "Are you sure?",
            message: "Do you want to decline this assignment?",
            isDisable: true,
         });
         setAction("decline")
    }

    const handleConfirmDecline = () => {
        dispatch(
            declineAssignment({
               handleResult,
               assignmentId: disableState.id,
            })
         );
    }

    const handleConfirmCreateRequest = () => {
        dispatch(
            updateUserAssignment({
                handleResult,
                assignmentId: disableState.id,
            })
        );
    };

    const handleShowCreateRequest = async (id: number) => {
        setDisable({
            id,
            isOpen: true,
            title: 'Are you sure',
            message: 'Do you want to create a returning request for this Asset?',
            isDisable: true,
        });
        setAction("request")
    };

    const handleCloseCreateRequest = () => {
        setDisable({
            isOpen: false,
            id: 0,
            title: "",
            message: "",
            isDisable: true,
        });
    };

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            handleCloseCreateRequest();
            fetchData();
            NotificationManager.success(
                `Update Asignment Successful`,
                `Remove Successful`,
                2000
            );
        } else {
            setDisable({
                ...disableState,
                title: "Can not create Request",
                message,
                isDisable: result,
            });
        }
    };

    return (
        <>
            <Table
                columns={columns}
                handleSort={handleSort}
                sortState={sortState}
                page={{
                    currentPage: assignments?.currentPage,
                    totalPage: assignments?.totalPages,
                    handleChange: handlePage,
                }}
            >
                {assignments?.items?.map((data, index) => (
                    <tr key={index} className="" onClick={() => handleShowInfo(Number(data.id))}>

                        <td id={data.assetCode}>
                            {data.assetCode}
                        </td>

                        <td id={data.assetName} className="asset-name">
                            {data.assetName}
                        </td>

                        <td id={data.categoryName} className="">
                            {data.categoryName}
                        </td>

                        <td /*id ={data.assignedDate}*/>
                            {data.assignedDate
                                ? (new Date(data.assignedDate).getDate() <= 9
                                    ? "0" + new Date(data.assignedDate).getDate()
                                    : new Date(data.assignedDate).getDate()) +
                                "/" +
                                (new Date(data.assignedDate).getMonth() < 9
                                    ? "0" + (new Date(data.assignedDate).getMonth() + 1)
                                    : new Date(data.assignedDate).getMonth() + 1) +
                                "/" +
                                new Date(data.assignedDate).getFullYear()
                                : ""}
                        </td>

                        <td id={data.assignmentState}>
                            {showState(data.assignmentState)}
                        </td>

                        <td className="d-flex justify-content-end">
                            {data.assignmentState === "Accepted" || data.assignmentState === "WaitingReturn" ? (
                                <>
                                    <ButtonIcon disable>
                                        <CheckLg className="text-danger" />
                                    </ButtonIcon>
                                    <ButtonIcon disable>
                                        <XLg className="text-black mx-2" />
                                    </ButtonIcon>
                                    {data.assignmentState === "WaitingReturn" ? 
                                    <ButtonIcon disable>
                                        <ArrowCounterclockwise id="arrow-counter" className="text-primary" />
                                    </ButtonIcon> :
                                    <ButtonIcon>
                                        <ArrowCounterclockwise id="arrow-counter" className="text-primary" onClick={() => handleShowCreateRequest(Number(data.id))} />
                                    </ButtonIcon>}
                                    
                                </>
                            ) : (
                                <>
                                    <ButtonIcon>
                                        <CheckLg className="text-black" onClick={() => handleShowAccept(Number(data.id))}/>
                                    </ButtonIcon>
                                    <ButtonIcon>
                                        <XLg className="text-danger mx-2" onClick={() => handleShowDecline(Number(data.id))}/>
                                    </ButtonIcon>
                                    <ButtonIcon disable>
                                        <ArrowCounterclockwise id="arrow-counter" className="" />
                                    </ButtonIcon>
                                </>
                            )}
                        </td>
                    </tr>
                ))}
            </Table>

            {assignmentDetail && showDetail && <Info assignment={assignmentDetail} handleClose={handleCloseDetail} />}

            <ConfirmModal
                title={disableState.title}
                isShow={disableState.isOpen}
                onHide={handleCloseCreateRequest}
            >
                <div>
                    <div className="ml-3">{disableState.message}</div>

                    <div className="ml-3 mt-3">
                        <button
                            className="btn btn-danger mr-3"
                            onClick={ action == "accept" ? handleConfirmAccept : action == "decline" ? handleConfirmDecline : handleConfirmCreateRequest}
                            type="button"
                        >
                            {action == "accept" ? "Accept" : action =="decline" ? "Decline" : "Yes"}
                        </button>

                        <button
                            className="btn btn-outline-secondary"
                            onClick={handleCloseCreateRequest}
                            type="button"
                        >
                            {action == "accept" ? "Cancel" : action == "decline" ? "Cancel" : "No"}
                        </button>
                    </div>

                </div>
            </ConfirmModal>

        </>
    );
};

export default UserAssignmentTable;