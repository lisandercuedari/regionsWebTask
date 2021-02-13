import React, { useState, useEffect } from 'react';
import 'App.css';
import 'antd/dist/antd.css';
import styled from "styled-components";
import { Layout } from 'antd';
import {
    Row, Col, Form, InputNumber, Button
} from 'antd';
import get from 'api/get';

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

export const GetEmployeesForm = () => {

    const [employees, setEmployees] = useState([]);
    const [apiResult, setApiResult] = useState({
        loading: false
    });

    const onSubmit = (values) => {
        setApiResult({
            loading: true
        });

        let tempFields = [];

        get("region/" + values["id"] + "/employees").then((result) => {

            result.forEach(element => {
                tempFields.push({
                    id: element.id,
                    firstName: element.firstName,
                    lastName: element.lastName,
                    regions: element.regions
                });
            });
            setEmployees(tempFields);
            setApiResult({
                loading: false
            });
        });
    }

    return (
        <Row style={{ backgroundColor: "white" }} gutter={[32, 32]}>
            <Col xl={12}>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                        <Form
                            labelCol={{ span: 16 }}
                            wrapperCol={{ span: 16 }}
                            layout="vertical"
                            requiredMark={false}
                            onFinish={onSubmit}
                        >
                            <Form.Item
                                label="Region Id"
                                name="id"
                                key="id">
                                <InputNumber />
                            </Form.Item>
                            <Form.Item>
                                <Button type="primary" htmlType="submit" loading={apiResult.loading}>
                                    {apiResult.loading ? "Fetching data..." : "Get employees"}
                                </Button>;
                            </Form.Item>
                        </Form>
                    </Col>
                </Row>
                <Row gutter={[16, 16]}>
                    <Col xl={24}>
                        {employees.map(element =>
                            <div>
                                <label>{element.firstName + " " + element.lastName + " from the Region of " + element.regions + ""}</label>
                            </div>)}
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
                        Please give a region Id in the given field. The application will return all the employees for that Region
                        (and any region that is a descendant of that region)
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
