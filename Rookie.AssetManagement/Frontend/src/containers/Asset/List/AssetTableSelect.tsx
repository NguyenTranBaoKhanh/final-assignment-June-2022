import React, { useState } from "react";
import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IAsset from "src/interfaces/Asset/IAsset";

const columns: IColumnOption[] = [
  { columnName: "", columnValue: "Radio"},
  { columnName: "Asset Code", columnValue: "AssetCode" },
  { columnName: "Asset Name", columnValue: "Name" },
  { columnName: "Category", columnValue: "Category" },
];

type Props = {
  assets: IPagedModel<IAsset> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
  handleSelect: Function;
  code: String
};

const AssetTableSelect: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  fetchData,
  handleSelect,
  code
}) => {
    const [selected, setSelected] = useState(code)
    const onSelected = (code: string) => {
        setSelected(code)
    }

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: assets?.page,
          totalPage: assets?.pageCount,
          handleChange: handlePage,
        }}
      >
        {assets?.items?.map((data, index) => (
          <tr className={`row-select__assignment ${data.assetCode == selected ? 'selected' : ''}`} key={index} 
                onClick={() => {handleSelect(data); onSelected(data.assetCode)}}>
            <td style={{borderBottom: "none"}}><div className={`radio__assignment ${data.assetCode == selected ? 'selected' : ''}`}></div></td>
            <td id = {data.assetCode}>{data.assetCode}</td>
            <td className="asset--name__overflow" id = {data.assetName}>{data.assetName}</td>
            <td style={{borderBottom: "2px solid #dee2e6"}} id ={data.categoryName}>{data.categoryName}</td>
          </tr>
        ))}
      </Table>
    </>
  );
};

export default AssetTableSelect;
