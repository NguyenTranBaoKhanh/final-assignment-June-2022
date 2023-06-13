import AuthorizeSagas from 'src/containers/Authorize/sagas';
import UserSagas from 'src/containers/User/sagas';
import AssetSagas from 'src/containers/Asset/sagas';
import AssignmentSaga from 'src/containers/Assignment/sagas';
import RequestSaga from 'src/containers/Request/sagas';
import UserAssignmentSaga from 'src/containers/Home/sagas';
export default [
    AuthorizeSagas,
    UserSagas,
    AssetSagas,
    AssignmentSaga,
    RequestSaga,
    UserAssignmentSaga
];
