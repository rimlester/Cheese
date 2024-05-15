import { useEffect, useState } from 'react';
import './App.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import CardBody from 'react-bootstrap/Card';

function App() {
    const [cheeses, setCheeses] = useState();

    useEffect(() => {
        populateCheeses();
    }, []);

    const contents = cheeses === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        :   <Row>
                {cheeses.map(cheese =>
                    <Col key={cheese.id}>
                        <Card style={{ width: '18rem' }} >
                            <Card.Img variant="bottom" src={cheese.url}/>
                            <Card.Body>
                                <Card.Title>{cheese.name}</Card.Title>
                                <Card.Text>${cheese.price}</Card.Text>
                            </Card.Body>
                            <CardBody>
                                <Card.Text>{cheese.description}</Card.Text>
                            </CardBody>
                        </Card>
                    </Col>
                )}
            </Row>;

    return (
        <Container fluid>
            <h1>Cheeses</h1>
            <p></p>
            {contents}
        </Container>
    );

    async function populateCheeses() {
        const response = await fetch('cheese');
        const data = await response.json();
        setCheeses(data);
    }
}

export default App;