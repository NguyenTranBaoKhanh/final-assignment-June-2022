import React from "react";
import { CloseButton, Modal } from "react-bootstrap";

import IAsset from "src/interfaces/Asset/IAsset";

import {
  StaffAssetType,
  StaffAssetTypeLabel,
  AdminAssetType,
  AdminAssetTypeLabel,
} from "src/constants/Asset/AssetConstants";

type Props = {
  asset: IAsset;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ asset, handleClose }) => {
  const getAssetTypeName = (id: number) => {
    return id == AdminAssetType ? AdminAssetTypeLabel : StaffAssetTypeLabel;
  };
  return (
    <>
      <Modal show={true} onHide={handleClose} dialogClassName="modal asset-detail-modal" centered>
        <Modal.Header>
          <Modal.Title id="asset-title-modal">Detail Asset Information</Modal.Title>
          <button className="close-button"
            onClick={handleClose}
          >
            <i className="fa-solid fa-xmark"></i>
          </button>
        </Modal.Header>
        <Modal.Body>
          <div>
            <div className="row">
              <div className="col-3">Asset Code:</div>
              <div>{asset.assetCode}</div>
            </div>
            <div className="row ">
              <div className="col-3">Asset Name:</div>
              <div className="col-9 pl-0">{asset.assetName}</div>
            </div>
            <div className="row ">
              <div className="col-3">Category:</div>
              <div>{asset.categoryName}</div>
            </div>
            <div className="row ">
              <div className="col-3">Installed Date:</div>
              <div>{(new Date(asset.installedDay).getDate() <= 9
                ? "0" + new Date(asset.installedDay).getDate()
                : new Date(asset.installedDay).getDate()) +
                "/" +
                (new Date(asset.installedDay).getMonth() < 9
                  ? "0" + (new Date(asset.installedDay).getMonth() + 1)
                  : new Date(asset.installedDay).getMonth() + 1) +
                "/" +
                new Date(asset.installedDay).getFullYear()}</div>
            </div>
            <div className="row ">
              <div className="col-3">State:</div>
              <div>{asset.assetState}</div>
            </div>
            <div className="row ">
              <div className="col-3">Location:</div>
              <div>{asset.locationID}</div>
            </div>
            <div className="row ">
              <div className="col-3">Specification:</div>
              <div style={{ paddingLeft: 0 }} className="col-9">{asset.specification}</div>
            </div>
            <div className="row ">
              <div className="col-3">History:</div>
              <div style={{ paddingLeft: 0 }} className="col-9">
                <table className="table asset-table" >
                  <thead>
                    <tr>
                      <th>Date</th>
                      <th>Assigned To</th>
                      <th>Assigned By</th>
                      <th>Returned Date</th>
                    </tr>
                  </thead>
                  <tbody>
                    <td>12/10/2018</td>
                    <td>minhtn</td>
                    <td>sangpv</td>
                    <td>07/03/2019</td>

                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default Info;
