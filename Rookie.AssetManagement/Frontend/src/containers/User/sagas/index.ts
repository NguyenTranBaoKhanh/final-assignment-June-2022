import { takeLatest } from 'redux-saga/effects';

import { createUser, disableUser, getUsers, updateUser } from '../reducer';
import { handleCreateUser, handleDisableUser, handleGetUsers, handleUpdateUser } from './handles';

export default function* UserSagas() {
    yield takeLatest(createUser.type, handleCreateUser);
    yield takeLatest(updateUser.type, handleUpdateUser);
    yield takeLatest(getUsers.type, handleGetUsers);
    yield takeLatest(disableUser.type, handleDisableUser);
}
