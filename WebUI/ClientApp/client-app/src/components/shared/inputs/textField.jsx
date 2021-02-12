import React from 'react'
import { Input } from 'antd'
import styled from "styled-components"

const ValidationLabel = styled.label`
color: red;
`

export const TextField = ({ title, type, name, prefix, suffix, error, onChange }) => {

        return (
                <React.Fragment>
                        <label>{title}</label>
                        <Input
                                name={name}
                                type={type}
                                prefix={prefix}
                                suffix={suffix}
                                onChange={onChange}>
                        </Input>
                        {error !== '' &&
                                <div><ValidationLabel>{error}</ValidationLabel></div>
                        }
                </React.Fragment>
        );
}
