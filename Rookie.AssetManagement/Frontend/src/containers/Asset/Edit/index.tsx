
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppSelector } from "src/hooks/redux";
import IAssetForm from "src/interfaces/Asset/IAssetForm";
import { number } from "yup";
import AssetFormContainer from "../AssetForm";


const EditAssetContainer = () => {
  const { assets } = useAppSelector(state => state.assetReducer);

    const [asset ,setAsset] = useState(undefined as IAssetForm | undefined);

    const { assetCode  } = useParams<{ assetCode : string}>();

    const existAsset = assets?.items.find(item => item.assetCode == assetCode );

    const formatDate = (date : string) => {
      const strings = date.split("-");
      const year = strings[0];
      const month = strings[1];
      const day = strings[2].slice(0,2);
      return new Date([month, day, year].join("/"));
    }
    useEffect(() => {
      console.log("HMCCC"+existAsset?.assetCode.toString());
      console.log("HMCCC1" + assets);
      console.log("HMCCC"+ existAsset?.assetCode);
      if(existAsset) {
          setAsset({
            assetCode: existAsset.assetCode,
            assetName: existAsset.assetName,
            assetState: existAsset.assetState,
            categoryID: existAsset.categoryID,
            categoryName: existAsset.categoryName,
            installedDay: formatDate(existAsset.installedDay.toString()),
            locationID: existAsset.locationID,
            specification: existAsset.specification
          });
      }
  }, [existAsset]);




  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
         Edit Asset
      </div>

      <div className='row'>
        {
         asset && (<AssetFormContainer 
          initialAssetForm={asset}
         />)
        }
      </div>
    </div>
  );
};

export default EditAssetContainer;