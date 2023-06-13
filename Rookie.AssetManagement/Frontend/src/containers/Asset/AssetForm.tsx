import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import { Link, useNavigate } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import TextField from 'src/components/FormInputs/TextField';
import TextAreaField from 'src/components/FormInputs/TextAreaField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import * as Yup from 'yup';
import { PARENT_ROOT } from 'src/constants/pages';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { CategoryOptions, StateOptionsUpdate, StateOptions } from 'src/constants/selectOptions'
import { createAsset, updateAsset } from './reducer';
import { Console } from 'console';


const initialFormValues: IAssetForm = {
    assetName: '',
    specification: '',
    categoryID: '',
    locationID: '',
    installedDay: undefined,
    assetState: 'Available'
}

const validationSchema = Yup.object().shape({
    assetName: Yup.string().required('Asset Name is required'),
    specification: Yup.string().required('Specification is required'),
    installedDay: Yup.date()
        .nullable()
        .required("Installed Date is required"),
    categoryID: Yup.string().required('Category is required'),
})

type Props = {
    initialAssetForm?: IAssetForm;
};

const AssetFormContainer: React.FC<Props> = ({ initialAssetForm = { ...initialFormValues } }) => {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const dispatch = useAppDispatch();
    const isUpdate = initialAssetForm.assetCode ? true : false;
    const { account } = useAppSelector(state => state.authReducer);
    initialAssetForm.locationID = account?.location

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Asset`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                navigate(PARENT_ROOT);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <Formik
            initialValues={initialAssetForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);
                setTimeout(() => {
                    if (isUpdate) {
                        console.log('update asset', values)
                        dispatch(updateAsset({ handleResult, formValues: values }));
                    }
                    else {
                        dispatch(createAsset({ handleResult, formValues: values }));
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => {
                return (
                    <Form>
                        <TextField
                            id="assetName"
                            name="assetName"
                            label="Name"
                            isrequired={true}
                        // disabled={isUpdate ? true : false}
                        />

                        <SelectField
                            id="categoryID"
                            name="categoryID"
                            label="Category"
                            isrequired={true}
                            options={CategoryOptions}
                            disabled={isUpdate ? true : false}
                        />

                        <TextAreaField
                            id="specification"
                            name="specification"
                            label="Specification"
                            isrequired={true}
                        />

                        <DateField
                            id="installedDay"
                            name="installedDay"
                            label="Installed Date"
                            isrequired={true}
                        />

                        <CheckboxField
                            className="assetState"
                            id="assetState"
                            name="assetState"
                            label="State"
                            isrequired={true}
                            options={isUpdate ? StateOptionsUpdate : StateOptions}
                        />


                        <div className="d-flex">
                            <div className="ml-auto">
                                <button className="btn btn-danger"
                                    type="submit" disabled={(!actions.values.assetName
                                        || !actions.values.specification
                                        || !actions.values.installedDay
                                        || !actions.values.categoryID
                                    )}
                                >
                                    Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                                </button>

                                <Link to={PARENT_ROOT} className="btn btn-outline-secondary ml-2">
                                    Cancel
                                </Link>
                            </div>
                        </div>
                    </Form>
                )
            }}
        </Formik>
    )
}



export default AssetFormContainer;