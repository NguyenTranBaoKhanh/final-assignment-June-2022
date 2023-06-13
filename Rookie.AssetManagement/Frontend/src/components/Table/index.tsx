import React from "react";
import { CaretDownFill, CaretUpFill } from "react-bootstrap-icons";
import NotFound from "src/containers/NotFound";
import IColumnOption from "src/interfaces/IColumnOption";
import Paging, { PageType } from "./Paging";

export type SortType = {
  columnValue: string;
  orderBy: boolean;
};

type ColumnIconType = {
  colValue: string;
  sortState: SortType;
};

const ColumnIcon: React.FC<ColumnIconType> = ({ colValue, sortState }) => {
  if (colValue === sortState.columnValue && sortState.orderBy === false)
    return <CaretUpFill />;
    
  return <CaretDownFill />;
};

type Props = {
  columns: IColumnOption[];
  children: React.ReactNode;
  sortState: SortType;
  handleSort: (colValue: string) => void;
  page?: PageType;
};

const Table: React.FC<Props> = ({
  columns,
  children,
  page,
  sortState,
  handleSort,
}) => {
  // console.log(page)

  return (
    <>
      <div className="table-container">
        <table className="table">
          <thead>
          
          <tr>
              {columns.map((col, i) => (
                <th style={{borderBottom: col.columnName.length ? "" : "none"}} key={i}>
                  <a
                    style={{display: col.columnName.length ? "" : "none"}}
                    className={col.columnValue == "AssignedBy" || col.columnValue == "AssignedTo" ? "btn lower-text-th" : "btn"}
                    onClick={() =>
                      col.columnValue == "UserName" || col.columnValue =="No."
                        ? " "
                        : handleSort!(col.columnValue) 
                    }
                  >
                    {col.columnName}
                    {col.columnValue == "UserName" || col.columnValue == "No." ? (
                      " "
                    ) : (
                      <ColumnIcon
                        colValue={col.columnValue}
                        sortState={sortState}
                      />
                    )}
                  </a>
                </th>
              ))}
            </tr>
          </thead>

          <tbody>{children}</tbody>
        </table>
      </div>
      {(page && page.totalPage && page.totalPage > 1 && (
        <Paging {...page} />
      )) === 0 ? (
        <NotFound />
      ) : (
        page && page.totalPage && page.totalPage > 1 && <Paging {...page} />
      )}
    </>
  );
};

export default Table;
