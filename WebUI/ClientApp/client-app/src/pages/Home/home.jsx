import React from 'react';
import 'App.css';
import 'antd/dist/antd.css';
import styled from "styled-components";
import { Layout } from 'antd';
import { HomeSider } from './components/homeSider';
import { Switch } from "react-router-dom";
import RouteWithSubRoutes from 'routes/routeWithSubRoutes';

const { Footer } = Layout;

const StyledLayout = styled(Layout)`
min-height: 100vh;
`

export const Home = ({ routes }) => {
    return (
        <StyledLayout>
            <HomeSider />
            <Layout>
                <Switch>
                    {routes.map((route, i) => (
                        <RouteWithSubRoutes key={i} {...route} />
                    ))}
                </Switch>
            </Layout>
        </StyledLayout>
    );
}
