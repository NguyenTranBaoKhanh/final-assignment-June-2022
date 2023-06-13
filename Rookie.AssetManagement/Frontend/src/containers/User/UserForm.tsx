import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useNavigate } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { PARENT_ROOT } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IUserForm from 'src/interfaces/User/IUserForm';
import { createUser, updateUser } from './reducer';
import { UserTypeOptions, GenderTypeOptions} from 'src/constants/selectOptions'

const checkSaturdayOrSunday = (date: any) => {
    return date == undefined 
        || date.getDay() == 0 
        || date.getDay() == 6 
        ? false 
        : true
}

const generateDateRequest = (...date: any[]): void => {
    date.forEach(d => d.setDate(d.getDate()))
}

const initialFormValues: IUserForm = {
    firstName : '',
    lastName : '',
    dateOfBirth : undefined,
    joinedDate: undefined,
    gender: 'F',
    type: '',
    locationID: ''
}

const validationSchema = Yup.object().shape({
    firstName: Yup.string().required('First Name is required')
    .test('alphabets', 'Name must only contain alphabets', (value) => {
        return /^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$/g
        .test(value as string);
    }),
    lastName: Yup.string().required('Last Name is required')
    .test('alphabets', 'Name must only contain alphabets', (value) => {
        return /^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$/g
        .test(value as string);
    }),
    dateOfBirth : Yup.date()
    .nullable()
    .required("Date of birth is required")
    .max(new Date(Date.now() - 567648000000), "User is under 18. Please select a different date"),
    joinedDate : Yup.date()
    .nullable()
    .when(
        'dateOfBirth',
        (dob, schema) => {
            if (dob) {
                return (dob && schema
                // .min(new Date(Date.parse(dob) + 567648000000), 'User under the age of 18 may not join company. Please select a different date')
                .required('Joinned date is required')
                .test(
                    "joinedDate",
                    "User under the age of 18 may not join company. Please select a different date",
                    (value: any) => {
                        if (new Date(value).getFullYear() - new Date(dob).getFullYear() > 18) {
                            return true
                        } else if (new Date(value).getFullYear() - new Date(dob).getFullYear() == 18 &&
                        new Date(value).getMonth() > new Date(dob).getMonth()){
                            return true
                        } else if (new Date(value).getFullYear() - new Date(dob).getFullYear() == 18 &&
                        new Date(value).getMonth() == new Date(dob).getMonth() &&
                        new Date(value).getDate() >= new Date(dob).getDate()
                        ) {
                            return true
                        }
                        return false
                    }
                )
                .test(
                    "joinedDate",
                    "Joined date is Saturday or Sunday. Please select a different date",
                    (value: any) => {
                        return checkSaturdayOrSunday(value);
                    }
                ))
            }
            return schema.test(
                "joinedDate",
                "Please select Date of birth",
                (value: any) => {
                   return false;
                }
            )
        },
    ),
    type: Yup.string().required('Type is required')
});

type Props = {
    initialUserForm?: IUserForm;
};

const UserFormContainer : React.FC<Props> = ({ initialUserForm  = { ...initialFormValues } }) => {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const dispatch = useAppDispatch();
    const isUpdate = initialUserForm.userId ? true : false;
    const { account } = useAppSelector(state => state.authReducer);
    initialUserForm.locationID = account?.location

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful User`,
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
            initialValues = {initialUserForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit = {(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(updateUser({ handleResult, formValues: values }));
                    }
                    else {
                        dispatch(createUser({ handleResult, formValues: values }));
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => {
                // actions.setFieldTouched('dateOfBirth', true)
                return (
                <Form className='intro-y col-lg-6 col-12'>
                    <TextField
                        id="firstName"
                        name="firstName" 
                        label="First Name"
                        disabled={isUpdate ? true : false}
                    />
                    <TextField
                        id="lastName"
                        name="lastName" 
                        label="Last Name"
                        disabled={isUpdate ? true : false} 
                    />
                     <DateField
                        id="dateOfBirth"
                        name="dateOfBirth"
                        label="Date of Birth"
                    />
                    <CheckboxField
                        id="gender"
                        name="gender"
                        label="Gender"
                        options={GenderTypeOptions}
                    />
                    <DateField
                        id="joinedDate"
                        name="joinedDate"
                        label="Joined Date"
                    /> 
                    <SelectField
                        id="type"
                        name="type"
                        label="Type"
                        options={UserTypeOptions}
                    />

                    <div className="d-flex">
                        <div className="ml-auto">
                            <button  className="btn btn-danger"
                                type="submit" 
                                disabled={(!actions.values.firstName
                                        || !actions.values.lastName
                                        || !actions.values.dateOfBirth 
                                        || !actions.values.joinedDate
                                        || !actions.values.type
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
                )}}
            </Formik>
    )
}
export default UserFormContainer;