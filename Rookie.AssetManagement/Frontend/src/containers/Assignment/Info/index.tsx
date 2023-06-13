import React from "react";
import { CloseButton, Modal } from "react-bootstrap";
import IAssignment from "src/interfaces/Assignment/IAssignment";

type Props = {
   assignment: IAssignment;
   handleClose: () => void;
};
const Info: React.FC<Props> = ({ assignment, handleClose }) => {

   const showState = (state : string | undefined) => {
      if(state === "WaitingReturn" ) {
          state = "Waiting for retunring";
      }
      else if(state === "Waiting") {
          state = "Waiting for acceptance";
      }
      return state;
  }

   return (
      <Modal show={true} onHide={handleClose} dialogClassName="modal-90w" centered>
         <Modal.Header>
            <Modal.Title>Detail Assignment Information</Modal.Title>
            <button className="close-button" onClick={handleClose}>
               <i className="fa-solid fa-xmark"></i>
            </button>
         </Modal.Header>
         <Modal.Body>
            <div>
               <div className="row">
                  <div className="col-4">Asset Code:</div>
                  <div>{assignment.assetCode}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Asset Name:</div>
                  <div className="col-8 pl-0">{assignment.assetName}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Specification:</div>
                  <div className="col-8 pl-0">{assignment.specifiCation}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Assigned to:</div>
                  <div>{assignment.assignedToUser}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Assigned by:</div>
                  <div>{assignment.assignedByUser}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Assigned Date:</div>
                  <div>
                     {assignment.assignedDate
                        ? (new Date(assignment.assignedDate).getDate() <= 9
                             ? "0" + new Date(assignment.assignedDate).getDate()
                             : new Date(assignment.assignedDate).getDate()) +
                          "/" +
                          (new Date(assignment.assignedDate).getMonth() < 9
                             ? "0" + (new Date(assignment.assignedDate).getMonth() + 1)
                             : new Date(assignment.assignedDate).getMonth() + 1) +
                          "/" +
                          new Date(assignment.assignedDate).getFullYear()
                        : ""}
                  </div>
               </div>
               <div className="row ">
                  <div className="col-4">State:</div>
                  <div> {showState(assignment.assignmentState)}</div>
               </div>
               <div className="row ">
                  <div className="col-4">Note:</div>
                  <div className="col-8 pl-0">{assignment.note}</div>
               </div>
            </div>
         </Modal.Body>
      </Modal>
   );
};

export default Info;
