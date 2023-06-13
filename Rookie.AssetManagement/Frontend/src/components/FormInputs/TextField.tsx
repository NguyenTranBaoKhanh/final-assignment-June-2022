import React, { InputHTMLAttributes, useState } from 'react';
import { useField } from 'formik';


type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    label: string
    placeholder?: string;
    name: string;
    isrequired?: boolean;
    notvalidate?: boolean;
    isPassword?: boolean;
    isSearch?: boolean
};

const TextField: React.FC<InputFieldProps> = (props) => {
    const [field, { error, touched }, meta] = useField(props);
    const { label, isrequired, notvalidate, isPassword, isSearch } = props;
    const [showPassword, setShowPassword] = useState(false);

    const validateClass = () => {
        if (touched && error) return 'is-invalid';
        if (notvalidate) return '';
        if (touched) return 'is-valid';

        return '';
    };

    const handleShowPassword = () => {
        if(isPassword && !showPassword) {
            return 'password';
        }
        return 'text';
    }

    return (
        <>
            <div className="mb-3 row">
                <label className="col-4 col-form-label d-flex">
                    {label}
                    {isrequired && (
                        <div className="invalid ml-1">*</div>
                    )}
                </label>
                <div className="col">
                    <input className={`form-control ${!isSearch ? '' : 'search'} ${validateClass()}`} {...field} {...props} type={handleShowPassword()}/>
                    {isPassword&& (
                        <i 
                            className={showPassword ? 
                                'fa-solid fa-eye-slash' : 
                                'fa-solid fa-eye'} 
                            id='icon-show-password' onClick={() => setShowPassword(!showPassword)}
                        >
                        </i>
                    )}
                    {isSearch && (
                        <i style={{position: 'absolute',
                                right: '25px',
                                top: '12px'}} 
                            className="fa-solid fa-magnifying-glass"></i>
                    )}
                    {error && touched && (
                        <div className='invalid'>{error}</div>
                    )}
                </div>
            </div>

        </>
    );
};
export default TextField;
