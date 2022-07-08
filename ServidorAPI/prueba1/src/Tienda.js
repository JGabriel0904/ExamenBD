import React,{Component} from 'react';
import { Container,Typography } from '@material-ui/core';
import Venta from './components/Venta/index.js';

export class Tienda extends Component{

    render(){
        return(
            <Container maxWidth="md">
                 <Venta />
            </Container>
        )
    }
}