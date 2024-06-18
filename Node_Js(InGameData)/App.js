const express = require('express');
const excelData = require('./Node_Js(Common)/')

const app = express();
const port = 3000;

app.use(express.json());
//app.use(compression());

app.get('/api/data', (req, res) => {
    console.log(req.params.userId);
    res.send('<h2>my sever</h2>');
});

app.listen(port, () =>{
    console.log(`server 실행 ${port}`);
});