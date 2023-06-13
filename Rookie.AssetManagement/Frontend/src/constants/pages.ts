export const LOGIN = '/login';

export const CHANGE_PASSWORD_FIRST_LOGIN = '/changePasswordFirstLogin';

export const HOME = '/';

export const NOTFOUND = '/notfound';

export const USER = 'user/*'

export const USER_LIST = '*'

export const USER_LIST_LINK = '/user'

export const CREATE_USER = 'create'

export const PARENT_ROOT = '..'

export const ASSET = 'asset/*'

export const LIST = '*'

export const CREATE = 'create'

export const ASSET_LIST_LINK = '/asset'

export const ASSIGNMENT_LIST_LINK = '/assignment'

export const ASSIGNMENT = 'assignment/*'

export const REQUEST = 'request/*'

export const REQUEST_LIST_LINK = '/request'

export const EDIT_USER = 'edit/:id';

export const EDIT_ASSET = 'edit/:assetCode';

export const EDIT_ASSIGNMENTS = 'edit/:assignmentId';

export const EDIT_USER_ID = (id: string | number) => `edit/${id}`;

export const EDIT_ASSET_ID = (assetCode: string | number ) => `edit/${assetCode}`;

export const EDIT_ASSIGNMENTS_ID = (assignmentId: number|string)=> `edit/${assignmentId}`;

export const USER_PARENT_ROOT = '..'

//change password
export const CHANGE_PASSWORD = '/user/changepassword';

