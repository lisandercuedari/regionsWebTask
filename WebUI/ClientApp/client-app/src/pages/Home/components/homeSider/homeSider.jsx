import React from 'react'
import { Layout, Menu } from 'antd'
import styled from "styled-components"
import {
    DropboxOutlined,
    QrcodeOutlined,
    HomeOutlined
} from '@ant-design/icons';
import { NavLink } from 'react-router-dom';

const { Sider } = Layout;
const { SubMenu } = Menu;

const SiderHeader = styled.div`
height: 32px;
  background: rgba(255, 255, 255, 0.2);
  margin: 16px;
`;

export const HomeSider = () =>
    <Sider collapsible collapsed={false}>
        <SiderHeader />
        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
            <SubMenu key="sub1" icon={<QrcodeOutlined />} title="Regions">
                <Menu.Item key="1"><NavLink to="/ui/regions/import">Import</NavLink></Menu.Item>
            </SubMenu>
        </Menu>
    </Sider>