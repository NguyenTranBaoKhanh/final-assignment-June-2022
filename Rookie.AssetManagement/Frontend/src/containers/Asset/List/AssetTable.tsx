import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IAsset from "src/interfaces/Asset/IAsset";
import formatDateTime from "src/utils/formatDateTime";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import {
  StaffAssetType,
  StaffAssetTypeLabel,
  AdminAssetType,
  AdminAssetTypeLabel,
} from "src/constants/Asset/AssetConstants";
import { EDIT_ASSET_ID } from "src/constants/pages";
import Info from "../Info";
import { disableAsset } from "../reducer";

const columns: IColumnOption[] = [
  { columnName: "Asset Code", columnValue: "AssetCode" },
  { columnName: "Asset Name", columnValue: "AssetName" },
  { columnName: "Category", columnValue: "Category" },
  { columnName: "State", columnValue: "AssetState" },
];

type Props = {
  assets: IPagedModel<IAsset> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
};

const AssetTable: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const dispatch = useAppDispatch();
  const [assetDetail, setAssetDetail] = useState(null as IAsset | null);
  const [showDetail, setShowDetail] = useState(false);
  const [disableState, setDisable] = useState({
    isOpen: false,
    assetCode: "",
    title: "",
    message: "",
    isDisable: true,
  });

  const getAssetTypeName = (id: number) => {
    return id == AdminAssetType ? AdminAssetTypeLabel : StaffAssetTypeLabel;
  };

  const handleShowDisable = async (assetCode: string) => {
    setDisable({
      assetCode,
      isOpen: true,
      title: 'Are you sure?',
      message: 'Do you want to delete this Asset?',
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      assetCode: "",
      title: "",
      message: "",
      isDisable: true,
    });
  };

  const handleEdit = (assetCode: string | number) => {
    navigate(EDIT_ASSET_ID(assetCode));
  };

  const handleConfirmDisable = () => {
    dispatch(
      disableAsset({
        handleResult,
        staffcode: disableState.assetCode,
      })
    );
  };

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      handleCloseDisable();
      fetchData();
      NotificationManager.success(
        `Remove Asset Successful`,
        `Remove Successful`,
        2000
      );
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

  const navigate = useNavigate();

  // console.log(query)

  const handleShowInfo = (assetCode: string) => {
    const asset = assets?.items.find((item) => item.assetCode === assetCode);

    if (asset) {
      setAssetDetail(asset);
      setShowDetail(true);
    }
  };

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
          <tr key={index} className="" onClick={() => handleShowInfo(data.assetCode)}>
            <td id={data.assetCode}>{data.assetCode}</td>
            <td id={data.assetName} className="asset-name">{data.assetName}</td>
            <td id={data.categoryName}>{data.categoryName}</td>
            <td id={data.assetState}>{data.assetState === "NotAvailable" ? "Not available" : data.assetState === "Waiting" ? "Waiting for recycling" : data.assetState}</td>
            <td className="d-flex justify-content-end">
              {data.assetState === "Assigned" ?
                <>
                  <ButtonIcon disable>
                    <PencilFill className="text-black"/>
                  </ButtonIcon>
                  <ButtonIcon disable>
                    <XCircle className="text-danger ml-2"/>
                  </ButtonIcon>
                </> :
                <>
                  <ButtonIcon>
                    <PencilFill className="text-black" onClick={() => handleEdit(data.assetCode)} />
                  </ButtonIcon>
                  <ButtonIcon>
                    <XCircle className="text-danger ml-2" onClick={() => handleShowDisable(data.assetCode)} />
                  </ButtonIcon>
                </>
              }
            </td>
          </tr>
        ))}
      </Table>
      {assetDetail && showDetail && (
        <Info asset={assetDetail} handleClose={handleCloseDetail} />
      )}
      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>
          <div className="ml-3">{disableState.message}</div>
          {disableState.isDisable && (
            <div className="ml-3 mt-3">
              <button
                className="btn btn-danger mr-3"
                onClick={handleConfirmDisable}
                type="button"
              >
                Delete
              </button>

              <button
                className="btn btn-outline-secondary"
                onClick={handleCloseDisable}
                type="button"
              >
                Cancel
              </button>
            </div>
          )}
        </div>
      </ConfirmModal>
    </>
  );
};

export default AssetTable;