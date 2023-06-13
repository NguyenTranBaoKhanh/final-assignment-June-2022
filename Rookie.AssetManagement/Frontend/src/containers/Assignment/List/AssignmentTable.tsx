import React, { useState } from "react";
import { ArrowCounterclockwise, PencilFill, XCircle } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";
import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import Info from "../Info";
import { deleteAssignment } from "../reducer";
import { updateUserAssignment} from "../../Home/reducer"
import { EDIT_ASSIGNMENTS_ID } from "src/constants/pages";

const columns: IColumnOption[] = [
   { columnName: "No.", columnValue: "No." },
   { columnName: "Asset Code", columnValue: "AssetCode" },
   { columnName: "Asset Name", columnValue: "AssetName" },
   { columnName: "Assigned to", columnValue: "AssignedTo" },
   { columnName: "Assigned by", columnValue: "AssignedBy" },
   { columnName: "Assigned Date", columnValue: "AssignedDate" },
   { columnName: "State", columnValue: "State" },
];

type Props = {
   assignments: IPagedModel<IAssignment> | null;
   handlePage: (page: number) => void;
   handleSort: (colValue: string) => void;
   sortState: SortType;
   fetchData: Function;
};

const AssignmentTable: React.FC<Props> = ({ assignments, handlePage, handleSort, sortState, fetchData }) => {
   const dispatch = useAppDispatch();
   const [showDetail, setShowDetail] = useState(false);
   const [assignmentDetail, setAssignmentDetail] = useState(null as IAssignment | null);
   const [disableState, setDisable] = useState({
      isOpen: false,
      id: 0,
      title: "",
      message: "",
      isDisable: true,
   });

   const [action, setAction] = useState("");

   const handleConfirmCreateRequest = () => {
      console.log(disableState.id)
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


   const handleShowDelete = async (id: number) => {
      setDisable({
         id,
         isOpen: true,
         title: "Are you sure?",
         message: "Do you want to delete this assignment?",
         isDisable: true,
      });
      setAction("delete")
   };

   const handleEdit = (assignmentId: number | string) => {
      navigate(EDIT_ASSIGNMENTS_ID(assignmentId));
   };

   const handleConfirmDelete = () => {
      dispatch(
         deleteAssignment({
            handleResult,
            assignmentId: disableState.id,
         })
      );
   };

   const handleResult = (result: boolean, message: string) => {
      if (result) {
         fetchData();
         handleCloseCreateRequest()
         if (action == 'request'){
            NotificationManager.success(`Create Request Successful`, `Create Successful`, 2000);
         } else {
            NotificationManager.success(`Delete Assignment Successful`, `Delete Successful`, 2000);
         }
         
      } else { 
         setDisable({
            ...disableState,
            title: action == 'request' ? 'Can not create Request' : 'Can not delete Assignment',
            message,
            isDisable: result,
         })
      }
   };

   const handleCloseDetail = () => {
      setShowDetail(false);
   };

   const handleShowInfo = (id: number | string) => {
      const assignment = assignments?.items.find((item) => item.id === id);
      if (assignment) {
         setAssignmentDetail(assignment);
         setShowDetail(true);
      }
   };

   const navigate = useNavigate();

   return (
      <>
         <Table
            columns={columns}
            handleSort={handleSort}
            sortState={sortState}
            page={{
               currentPage: assignments?.page,
               totalPage: assignments?.pageCount,
               handleChange: handlePage,
            }}
         >
            {assignments?.items?.map((data, index) => (
               <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
                  <td>{assignments.page * assignments.limit - assignments.limit + index + 1}</td>
                  <td id={data.assetCode}>{data.assetCode}</td>
                  <td id={data.assetName} className="asset-name">
                     {data.assetName}
                  </td>
                  <td id={data.assignedToUser}>{data.assignedToUser}</td>
                  <td id={data.assignedByUser}>{data.assignedByUser}</td>
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
                     {data.assignmentState === "Waiting" ? "Waiting for acceptance" : data.assignmentState}
                  </td>

                  <td className="d-flex justify-content-end">
                     {data.assignmentState === "Accepted" ? (
                        <>
                           <ButtonIcon disable>
                              <PencilFill className="text-black" />
                           </ButtonIcon>
                           <ButtonIcon disable>
                              <XCircle className="text-danger mx-2" />
                           </ButtonIcon>
                           <ButtonIcon>
                              <ArrowCounterclockwise id="arrow-counter" className="text-primary" onClick={() => handleShowCreateRequest(Number(data.id))} />
                           </ButtonIcon>
                        </>
                     ) : (
                        <>
                           <ButtonIcon>
                              <PencilFill className="text-black" onClick={() => handleEdit(Number(data.id))} />
                           </ButtonIcon>
                           <ButtonIcon>
                              <XCircle className="text-danger mx-2" onClick={() => handleShowDelete(Number(data.id))} />
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
                            onClick={ action == "delete" ?  handleConfirmDelete : handleConfirmCreateRequest}
                            type="button"
                        >
                            {action == "request" ? 'Yes' : 'Delete'}
                        </button>

                        <button
                            className="btn btn-outline-secondary"
                            onClick={handleCloseCreateRequest}
                            type="button"
                        >
                            {action == 'request' ? 'No' : 'Cancel'}
                        </button>
                    </div>

                </div>
            </ConfirmModal>
      </>
   );
};

export default AssignmentTable;
