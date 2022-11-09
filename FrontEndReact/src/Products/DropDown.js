import { useState, useEffect, useCallback } from 'react';

function DropDown(props) {
    const [items, setItems] = useState([]);
    const url = props.url;
    // const url = 'http://localhost:5284/category';

    const fetchItems = useCallback(async () =>{
        const response = await fetch(url);
        const jason = await response.json();
        setItems(jason);
    },[setItems]);

    useEffect(() =>{
        fetchItems();
    }, [fetchItems]);

    return <div>
        <select className={props.className} onChange={props.onSelect} value={props.value} name={props.name} id={props.id}>
            <option value="none" selected disabled hidden>Select a Category</option>
            {items.map(item => <option key={item.id} value={item.id}>{item.name}</option>)}
        </select>
    </div>
}

export default DropDown;