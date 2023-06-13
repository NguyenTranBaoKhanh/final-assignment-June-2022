import ISelectOption from "src/interfaces/ISelectOption";

export const FilterUserType: ISelectOption[] = [
    { id: 1, label: 'All', value: 'All' },
    { id: 2, label: 'Admin', value: 'Admin' },
    { id: 3, label: 'Staff', value: 'Staff' },
];

export const GenderTypeOptions: ISelectOption[] = [
    { id: 1, label: 'Female', value: 'F' },
    { id: 2, label: 'Male', value: 'M' },
];

export const UserTypeOptions: ISelectOption[] = [
    { id: 1, label: 'Admin', value: 'Admin' },
    { id: 2, label: 'Staff', value: 'Staff' },
];

export const CategoryOptions: ISelectOption[] = [
    { id: 1, label: 'Monitor', value: 'MO' },
    { id: 2, label: 'Laptop', value: 'LA' },
    { id: 3, label: 'Personal Computer', value: 'PC' },
];

export const StateOptions: ISelectOption[] = [
    { id: 1, label: 'Available', value: 'Available' },
    { id: 2, label: 'Not Available', value: 'NotAvailable' },
    //{ id: 3, label: 'Waiting for recycling', value: 'Waiting' },
    //{ id: 4, label: 'Recycled', value: 'Recycled' },
    //{ id: 5, label: 'Assigned', value: 'Assigned' },
];

export const StateOptionsUpdate: ISelectOption[] = [
    { id: 1, label: 'Available', value: 'Available' },
    { id: 2, label: 'Not Available', value: 'NotAvailable' },
    { id: 3, label: 'Waiting for recycling', value: 'Waiting' },
    { id: 4, label: 'Recycled', value: 'Recycled' },
];

export const FilterAssetCategoriesOptions: ISelectOption[] = [
    { id: 1, label: 'All', value: 0 },
    { id: 2, label: 'Monitor', value: 'MO' },
    { id: 3, label: 'Laptop', value: 'LA' },
    { id: 4, label: 'Personal Computer', value: 'PC' },
];

export const FilterAssetStatesOptions: ISelectOption[] = [
    { id: 1, label: 'All', value: 0 },
    { id: 2, label: 'Available', value: 1 },
    { id: 3, label: 'Assigned', value: 2 },
    { id: 4, label: 'Waiting for recycling', value: 3 },
    { id: 5, label: 'Recycled', value: 4 },
    { id: 6, label: 'Not Available', value: 5 },
];

export const FilterAssignmentStatesOptions: ISelectOption[] = [
    { id: 1, label: 'All', value: 0 },
    { id: 2, label: 'Accepted', value: 1 },
    { id: 3, label: 'Waiting for acceptance', value: 2 },
];

export const FilterRequestStatesOptions: ISelectOption[] = [
    { id: 1, label: 'All', value: 0 },
    { id: 2, label: 'Completed', value: 1 },
    { id: 3, label: 'Waiting for returning', value: 2 },
];