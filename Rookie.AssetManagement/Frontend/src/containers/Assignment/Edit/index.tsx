
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppSelector } from "src/hooks/redux";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";
import AssignmentFormContainer from "../AssignmentForm";


const EditAssignmentContainer = () => {

  const { assignments } = useAppSelector(state => state.assignmentReducer);

  const [assignment, setAssignment] = useState(undefined as IAssignmentForm | undefined);

  const { assignmentId } = useParams<{ assignmentId: string }>();

  const existAssignment = assignments?.items.find(item => item.id == assignmentId);

  const formatDate = (date: string) => {
    const strings = date.split("-");
    const year = strings[0];
    const month = strings[1];
    const day = strings[2].slice(0, 2);
    return new Date([month, day, year].join("/"));
  }

  useEffect(() => {
    if (existAssignment) {
      setAssignment({
        fullName: existAssignment.fullName,
        assignmentId: existAssignment.id,
        staffCode: existAssignment.assignedToUser,
        assetCode: existAssignment.assetCode,
        assignedDate: formatDate(existAssignment.assignedDate.toString()),
        note: existAssignment.note,
        assetName: existAssignment.assetName
      });
    }
  }, [existAssignment]);

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Edit Assignment
      </div>

      <div className='row'>
        {
          assignment && (<AssignmentFormContainer
            initialAssignmentForm={assignment}
          />)
        }
      </div>
    </div>
  );
};

export default EditAssignmentContainer;