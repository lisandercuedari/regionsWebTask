import React, { useState, useEffect } from 'react';
import 'App.css';
import 'antd/dist/antd.css';
import styled from "styled-components";
import { Layout } from 'antd';
import {
    Row, Col
} from 'antd';

const { Header, Content } = Layout;

const StyledLabel = styled.label`
font-style: ${props => props.fontStyle || "normal"};
font-weight: ${props => props.fontWeight || 400};
cursor: ${props => props.cursor || "default"};
`

const ErrorDiv = styled.div`
color: #ff3838;
font-weight: 500;
margin-bottom: ${props => props.marginBottom};
`

const SuccessDiv = styled.div`
color: green;
font-weight: 500;
margin-bottom: ${props => props.marginBottom};
`

export const ImportRegionsForm = ({ routes }) => {

    return (
        <Row style={{ backgroundColor: "white" }} gutter={[32, 32]}>
            <Col xl={12}>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                        <label style={{ fontWeight: "500" }}>Text</label>
                    </Col>
                </Row>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                    Text
                    </Col>
                </Row>
            </Col>
            <Col xl={12}>
            <Row gutter={[16, 16]}>
                    <Col xl={24}>
                        Information
                    </Col>
                </Row>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                    </Col>
                </Row>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                    </Col>
                </Row>
            </Col>
        </Row>
    );
}
