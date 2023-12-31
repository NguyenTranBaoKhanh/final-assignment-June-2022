import { takeLatest } from 'redux-saga/effects';

import { changePassword, changePasswordFirstLogin, login, me } from 'src/containers/Authorize/reducer';
import { handleLogin, handleGetMe, handleChangePassword, handleChangePasswordFirstLogin } from 'src/containers/Authorize/sagas/handles';

export default function* authorizeSagas() {
    yield takeLatest(login.type, handleLogin),
    yield takeLatest(me.type, handleGetMe),
    yield takeLatest(changePassword.type, handleChangePassword)
    yield takeLatest(changePasswordFirstLogin.type, handleChangePasswordFirstLogin)
}
