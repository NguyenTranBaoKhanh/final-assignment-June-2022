import React, { useState } from "react";
import { ArrowCounterclockwise, CheckLg, PencilFill, XCircle, XLg } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IRequest from "src/interfaces/Request/IRequest";
import formatDateTime from "src/utils/formatDateTime";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import {
   StaffAssetType,
   StaffAssetTypeLabel,
   AdminAssetType,
   AdminAssetTypeLabel,
} from "src/constants/Asset/AssetConstants";
// import Info from "../Info";
// import { deleteAssignment } from "../reducer";

const columns: IColumnOption[] = [
   { columnName: "No.", columnValue: "No." },
   { columnName: "Asset Code", columnValue: "AssetCode" },
   { columnName: "Asset Name", columnValue: "AssetName" },
   { columnName: "Request by", columnValue: "RequestBy" },
   { columnName: "Assigned Date", columnValue: "AssignedDate" },
   { columnName: "Accepted by", columnValue: "AcceptedBy" },
   { columnName: "Returned Date", columnValue: "ReturnedDate" },
   { columnName: "State", columnValue: "State" },
];

type Props = {
   requests: IPagedModel<IRequest> | null;
   handlePage: (page: number) => void;
   handleSort: (colValue: string) => void;
   sortState: SortType;
   fetchData: Function;
};

const RequestTable: React.FC<Props> = ({ requests, handlePage, handleSort, sortState, fetchData }) => {
   const dispatch = useAppDispatch();
   console.log('request', requests)
   const [showDetail, setShowDetail] = useState(false);
   const [requestDetail, setRequestDetail] = useState(null as IRequest | null);
   const [disableState, setDisable] = useState({
      isOpen: false,
      id: 0,
      title: "",
      message: "",
      isDisable: true,
   });

   const getAssetTypeName = (id: number) => {
      return id == AdminAssetType ? AdminAssetTypeLabel : StaffAssetTypeLabel;
   };

   const handleShowDisable = async (id: number) => {
      setDisable({
         id,
         isOpen: true,
         title: "Are you sure?",
         message: "Do you want to delete this assignment?",
         isDisable: true,
      });
   };

   // const handleConfirmDisable = () => {
   //    dispatch(
   //       deleteAssignment({
   //          handleResult,
   //          assignmentId: disableState.id,
   //       })
   //    );
   // };

   const handleCloseDisable = () => {
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
         handleCloseDisable();
         fetchData();
         NotificationManager.success(`Remove Asset Successful`, `Remove Successful`, 2000);
      } else {
         setDisable({
            ...disableState,
            title: "Can not disable Asset",
            message,
            isDisable: result,
         });
      }
   };

   const handleCloseDetail = () => {
      setShowDetail(false);
   };

   const handleShowInfo = (id: number | undefined) => {
      const request = requests?.items.find((item) => item.id === id);
      if (request) {
         setRequestDetail(request);
         setShowDetail(true);
      }
   };

   const showState = (state: string | undefined) => {
      if (state === "Complected") {
          state = "Complected";
      }
      else if (state === "Waiting") {
          state = "Waiting for returning";
      }
      return state;
  }

   const navigate = useNavigate();

   // console.log(query)

   return (
      <>
         <Table
            columns={columns}
            handleSort={handleSort}
            sortState={sortState}
            page={{
               currentPage: requests?.page,
               totalPage: requests?.pageCount,
               handleChange: handlePage,
            }}
         >
            {requests?.items?.map((data, index) => (
               <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
                  <td>{requests.page * requests.limit - requests.limit + index + 1}</td>
                  <td id={data.assetCode}>{data.assetCode}</td>
                  <td id={data.assetName} className="asset-name">
                     {data.assetName}
                  </td>
                  <td id={data.requestedBy}>{data.requestedBy}</td>
                  <td>
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
                  <td id={data.acceptedBy}>{data.acceptedBy}</td>
                  <td>
                     {data.returnedDate
                        ? (new Date(data.returnedDate).getDate() <= 9
                           ? "0" + new Date(data.returnedDate).getDate()
                           : new Date(data.returnedDate).getDate()) +
                        "/" +
                        (new Date(data.returnedDate).getMonth() < 9
                           ? "0" + (new Date(data.returnedDate).getMonth() + 1)
                           : new Date(data.returnedDate).getMonth() + 1) +
                        "/" +
                        new Date(data.returnedDate).getFullYear()
                        : ""}
                  </td>
                  {/* <td id={data.requestState}>
                     {data.requestState === "Complected" ? "Waiting for returning" : data.requestState}
                  </td> */}
                  <td id={data.requestState}>
                            {showState(data.requestState)}
                        </td>

                  <td className="d-flex justify-content-end">
                     {data.requestState === "Complected" ? (
                        <>
                           <ButtonIcon disable>
                              <CheckLg className="text-danger" />
                           </ButtonIcon>
                           <ButtonIcon disable>
                              <XLg className="text-black mx-2" />
                           </ButtonIcon>
                        </>
                     ) : (
                        <>
                           <ButtonIcon >
                              <CheckLg className="text-danger" />
                           </ButtonIcon>
                           <ButtonIcon >
                              <XLg className="text-black mx-2" />
                           </ButtonIcon>
                        </>
                     )}
                  </td>
               </tr>
            ))}
         </Table>

         {/* {assignmentDetail && showDetail && <Info assignment={assignmentDetail} handleClose={handleCloseDetail} />} */}

         <ConfirmModal title={disableState.title} isShow={disableState.isOpen} onHide={handleCloseDisable}>
            <div>
               <div className="ml-3">{disableState.message}</div>
               {disableState.isDisable && (
                  <div className="ml-3 mt-3">
                     {/* <button className="btn btn-danger mr-3" type="button" onClick={handleConfirmDisable}>
                        Delete
                     </button> */}

                     <button className="btn btn-outline-secondary" onClick={handleCloseDisable} type="button">
                        Cancel
                     </button>
                  </div>
               )}
            </div>
         </ConfirmModal>
      </>
   );
};

export default RequestTable;
