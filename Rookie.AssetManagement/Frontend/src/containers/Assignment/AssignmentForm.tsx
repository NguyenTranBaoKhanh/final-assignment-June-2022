import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import { Link, useNavigate } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import TextField from 'src/components/FormInputs/TextField';
import TextAreaField from '../../components/FormInputs/TextAreaField';
import DateField from '../../components/FormInputs/DateField';
import Dialog from '../../components/Dialog'
import UserSelect from '../../containers/User/List/UserSelect'
import AssetSelect from 'src/containers/Asset/List/AssetSelect'
import * as Yup from 'yup';
import { PARENT_ROOT } from '../../constants/pages';
import IAssignmentForm from '../../interfaces/Assignment/IAssignmentForm';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { createAssignment, updateAssignment } from './reducer';

const initialFormValues: IAssignmentForm = {
    staffCode: '',
    assetCode: '',
    assignedDate: new Date(),
    note: '',
    fullName: '',
    assetName: ''
}

const validationSchema = Yup.object().shape({
    assignedDate : Yup.date().nullable()
    .required("Assiged Date is required")
    .test(
        "assignedDate",
        "Admin can select only current or future date for Assigned Date",
        (value) => {
            if (value == undefined || new Date(value) > new Date(Date.now() - 86400000)){
                return true
            }
            return false;
        }
    ),
    note: Yup.string().required('Note is required'),
    fullName: Yup.string().required('User is required'),
    assetName: Yup.string().required('Asset is required')
})

type Props = {
    initialAssignmentForm?: IAssignmentForm;
};

const AssignmentFormContainer : React.FC<Props> = ({ initialAssignmentForm  = { ...initialFormValues } }) => {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(false);
    const [assignmentForm, setAssignmentForm] = useState(initialAssignmentForm)
    const [asset, setAsset] = useState({
        assetCode: '',
        assetName: ''
    })
    const [user, setUser] = useState({
        staffCode: '',
        firstName: '',
        lastName: ''
    })

    const [note, setNote] = useState('')
    const [assignedDate, setAssignedDate] = useState(new Date())
    
    const navigate = useNavigate();
    const isUpdate = initialAssignmentForm.assignmentId ? true : false;
    const [showUserModal, setShowUserModal] = useState(false);
    const [showAssetModal, setShowAssetModal] = useState(false);

    const openUserModal = () => {
        setShowUserModal(true);
    };

    const openAssetModal = () => {
        setShowAssetModal(true);
    };

    const handleCancleUser = () => {
        setShowUserModal(false);
    };

    const handleCancleAsset = () => {
        setShowAssetModal(false);
    };

    const handleSelectUser = (data) => {
        setUser(data)
    }

    const handleSelectAsset = (data) => {
        setAsset(data)
    }

    const confirmSaveUser = () => {
        if(user){
            const _assignmentForm = {...assignmentForm}
            _assignmentForm.note = note
            _assignmentForm.assignedDate = assignedDate
            _assignmentForm.staffCode = user.staffCode
            const fullName = user.firstName + " " + user.lastName
            _assignmentForm.fullName = fullName
            setAssignmentForm(_assignmentForm)
        }
        setShowUserModal(false);
    };

    const confirmSaveAsset = () => {
        if(asset){
            const _assignmentForm = {...assignmentForm}
            _assignmentForm.note = note
            _assignmentForm.assignedDate = assignedDate
            _assignmentForm.assetCode = asset.assetCode
            _assignmentForm.assetName = asset.assetName
            setAssignmentForm(_assignmentForm)
        }
        setShowAssetModal(false);
    };

    
    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Assignment`,
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
            initialValues = {assignmentForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit = {(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        console.log('update assignment success', values)
                        dispatch(updateAssignment({ handleResult, formValues: values }));
                    }
                    else {
                        console.log(values)
                        dispatch(createAssignment({ handleResult, formValues: values }));
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => {
                setAssignedDate(actions.values.assignedDate as Date)
                setNote(actions.values.note)
                return (
                    <Form>
                        <TextField
                            style={{cursor: 'pointer'}}
                            id="fullName"
                            name="fullName"
                            label="User"
                            isrequired={true}
                            onClick={openUserModal}
                            onKeyDown={e => e.preventDefault()}
                            isSearch={true}
                        />

                        <TextField
                            style={{cursor: 'pointer'}}
                            id="assetName"
                            name="assetName"
                            label="Asset"
                            isrequired={true}
                            onClick={openAssetModal}
                            onKeyDown={e => e.preventDefault()}
                            isSearch={true}
                        />

                        <DateField
                            id="assignedDate"
                            name="assignedDate"
                            label="Assigned Date"
                            isrequired={true}
                        />

                        <TextAreaField 
                            id="note"
                            name="note"
                            label="Note"
                            isrequired={true}
                        />

                    <Dialog
                        name="user"
                        title="Select User"
                        isShow={showUserModal}
                        onHide={handleCancleUser}
                    >
                        <div>
                            <UserSelect code={user.staffCode}  handleSelectUser={handleSelectUser}/>
                            <div className="text-center mt-3">
                                <button
                                    className="btn btn-danger mr-3"
                                    onClick={confirmSaveUser}
                                    type="button"
                                    >
                                    Save
                                </button>
                                <button
                                    className="btn btn-outline-secondary"
                                    onClick={handleCancleUser}
                                    type="button"
                                    >
                                    Cancel
                                </button>
                            </div>
                        </div>
                    </Dialog>

                    <Dialog
                        name="asset"
                        title="Select Asset"
                        isShow={showAssetModal}
                        onHide={handleCancleAsset}
                    >
                        <div>
                            <AssetSelect code={asset.assetCode} handleSelectAsset={handleSelectAsset}/>
                            <div className="text-center mt-3">
                                <button
                                    className="btn btn-danger mr-3"
                                    onClick={confirmSaveAsset}
                                    type="button"
                                    >
                                    Save
                                </button>
                                <button
                                    className="btn btn-outline-secondary"
                                    onClick={handleCancleAsset}
                                    type="button"
                                    >
                                    Cancel
                                </button>
                            </div>
                        </div>
                    </Dialog>
                        
                    <div className="d-flex">
                        <div className="ml-auto">
                            <button  className="btn btn-danger"
                                type="submit" disabled={(!actions.values.note 
                                    || !actions.values.assignedDate
                                    || !actions.values.fullName
                                    || !actions.values.assetName
                                )}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to = { PARENT_ROOT } className="btn btn-outline-secondary ml-2">
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

export default AssignmentFormContainer;