import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppSelector } from "src/hooks/redux";
import IUserForm from "src/interfaces/User/IUserForm";
import { number } from "yup";
import UserFormContainer from "../UserForm";

const UpdateUserContainer = () => {

    const { users } = useAppSelector(state => state.userReducer);

    const [user, setUser] = useState(undefined as IUserForm | undefined);

    const { id } = useParams<{ id: string}>();

    const existUser = users?.items.find(item => item.id === Number(id));

    const formatDate = (date : string) => {
        const strings = date.split("-");
        const year = strings[0];
        const month = strings[1];
        const day = strings[2].slice(0,2);
        return new Date([month, day, year].join("/"));
    }

    useEffect(() => {

        if(existUser) {
            console.log(formatDate(existUser.joinedDate.toString()));
            
            setUser({
                userId: existUser.id,
                firstName: existUser.firstName,
                lastName: existUser.lastName,
                dateOfBirth: formatDate(existUser.dateOfBirth.toString()),
                gender: existUser.gender,
                joinedDate: formatDate(existUser.joinedDate.toString()),
                type: existUser.type
            });
        }
    }, [existUser]);
    
    
    return (
        <div className='ml-5'>
            <div className='primaryColor text-title intro-x'>
                Edit User
            </div>

            <div className='row'>
                {
                    user && (<UserFormContainer
                        initialUserForm={user}
                    />)
                }
            </div>
        </div>
    )
};

export default UpdateUserContainer;