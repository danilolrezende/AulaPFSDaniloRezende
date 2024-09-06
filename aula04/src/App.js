import React, { useState, useRef } from 'react';

const textos = [
  { id: 1, texto: "teste1" },
  { id: 2, texto: "teste2" },
  { id: 3, texto: "teste3" },
  { id: 4, texto: "teste4" },
  { id: 5, texto: "teste5" },
];

function Item({ item }) {
  return <li>{item.texto}</li>;
}

function App() {
  //const [nome, setNome] = useState('');
  const [msg, setMsg] = useState('');
  const inputRef = useRef(null);

  <div>
    <ul>
      {textos.map(x => <Item key={x.id} item={x} />)}
    </ul>
    <div>
      <label>Nome</label>
      <input
        style={{ marginLeft: '10px', marginRight: '10px' }}
        type="text" id="nome"
        ref={inputRef} 
/*         value={nome}
        onChange={e => setNome(e.target.value)} */
      />
      {/* <button onClick={() => setMsg(`Olá ${nome}`)}>Mostrar</button> */}
      <button onClick={() => setMsg(`Olá ${inputRef.current.value }`)}>Mostrar</button>
      <p>{msg}</p>
    </div>
  </div>
}

export default App;
