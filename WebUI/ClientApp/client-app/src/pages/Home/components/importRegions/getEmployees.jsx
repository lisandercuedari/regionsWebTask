import React, { useState, useEffect } from 'react';
import 'App.css';
import 'antd/dist/antd.css';
import styled from "styled-components";
import { Layout } from 'antd';
import { Col, Row } from 'antd';
import { GetEmployeesForm } from './importRegionsForm/getEmployeesForm';

const { Header, Content } = Layout;

const ContentHeader = styled(Header)`
background: white;
padding: 0;
`

const StyledDivBody = styled.div`
padding: 24px;
min-height: 360px;
`;

const StyledContent = styled(Content)`
margin: 0 16px;
`

export const GetEmployees = ({ routes }) => {

    return (
        <React.Fragment>
            <ContentHeader />
            <StyledContent>
                <StyledDivBody>
                    <div>
                        <Row gutter={[16, 32]} align="middle" justify="left">
                            <Col xl={20}>
                                <span style={{ fontSize: '1.3em', fontWeight: '600' }}>Employees for region</span>
                            </Col>
                        </Row>
                        <GetEmployeesForm />
                    </div>
                </StyledDivBody>
            </StyledContent>
        </React.Fragment>
    );
}
