import React from 'react';
import { Spin } from 'antd';

const Backdrop = (props) => {
    return (
        props.visibility ?
            <div style={{
                position: "absolute",
                top: "0",
                height: "100%",
                width: "100%",
                textAlign: "center",
                background: "#0000001c",
                display: "flex",
                alignItems: "center",
                justifyContent: "center"
            }}>
                <Spin tip="Loading..." />
            </div> : null
    );
}

export default Backdrop;