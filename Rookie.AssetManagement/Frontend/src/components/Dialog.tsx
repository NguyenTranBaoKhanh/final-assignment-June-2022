import React, { Fragment } from "react";
import { Modal } from 'react-bootstrap';

type Props = {
    name: string
    title: string,
    isShow: boolean,
    onHide?: (() => void),
    children: React.ReactNode,
}

const Dialog: React.FC<Props> = ({ title, isShow, onHide, children, name }) => {

    return (
        <Modal
            show={isShow}
            onHide={onHide}
            dialogClassName={`component--dialog modal-90w`}
        >
            <Modal.Header>
                <Modal.Title>
                    {title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Fragment>
                    {children}
                </Fragment>
            </Modal.Body>
        </Modal>
    );
};

export default Dialog;
