
import React, { SetStateAction, useEffect, useState } from 'react'
import {Container,Row,Col, CardImgProps} from 'reactstrap'
import {iquest} from '../interfaces'
import {Quest} from './quest' 
import {Edu} from './edu'
interface iprops {children : React.ReactNode,opt?:string}              
export const All =({children,opt}:iprops)=>{

   let [Quests,setQuests]=useState<[iquest]>()
useEffect(()=>{
    FetchData();
},[])
const  FetchData= ()=>{

      fetch ("https://localhost:5001/api/Home",{
        method:"GET",
        headers:{"Content-Type":"application/json", 'Access-Control-Allow-Origin':'*'}
    })
    .then(res=>res.json())
      .then (jsn=>{  setQuests(jsn[0])} )
    
    .catch((err) =>
        console.log(err))

}

    return (
<Container>
{Array.isArray(Quests) && Quests? Quests?.map((ele:iquest,i:number)=>{
return (
    <Quest {...ele}  />
)
}):<React.Fragment>
    {opt && <Edu/>}
    {children}
    </React.Fragment>}

</Container>
    )
}