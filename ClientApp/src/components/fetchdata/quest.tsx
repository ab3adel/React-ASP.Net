import React from 'react'
import { Row,Col } from 'reactstrap'
import {iquest} from '../interfaces'
import {Link} from 'react-router-dom'
export const Quest =({title,content,limit,state,enddate,created,questID}:iquest)=>{

    const deletequest =(id:number) :void=>{
        fetch(`https://localhost:5001/api/Home/deletequest/${id}`,{
            method:"DELETE"
        })
        .then(res=>console.log(res))
        .catch(err=>console.log(err))
    }
    
    return (
        <Row  key={questID}>
        <Col md="3">{title}</Col> <Col md="3">{content}</Col> 
        <Col md="3">{limit}</Col> <Col md="3">{enddate}</Col>
        <Col md="6">{state}</Col><Col md="6">{created}</Col>
        <Col md="12">
            <Link to ={{pathname:`updatequest/${questID}`,state:{id:questID}}} >update</Link>
            <Link to ='/' onClick ={() =>deletequest(questID)} >Delete</Link>
        </Col>
    </Row>
    )
}