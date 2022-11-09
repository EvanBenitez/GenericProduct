import DropDown from "./DropDown";
import { Fragment, useCallback, useState } from 'react';

const postUrl='http://localhost:5284/product';

function AddProduct() {
    const [name, setName] = useState('');
    const [price, setPrice] = useState(0);
    const [description, setDescription] = useState('');
    const [category, setCategory] = useState('none');
    const [quantity, setQuantity] = useState(0);

    const onSelectCategoryHandler = (event) => {
        setCategory(event.target.value);
    };

    const onNameHandler = (event) => {
        setName(event.target.value);
    };

    const onPriceHandler = (event) => {
        setPrice(event.target.value);
    };

    const onDescriptionHandler = (event) => {
        setDescription(event.target.value);
    };

    const onQuantityHandler = (event) => {
        setQuantity(event.target.value);
    };

    const onSubmitHandler = async (event) => {
        event.preventDefault();
        if(name.trim != '' && category != 'none')
        {
            const response = await fetch(postUrl,{
                method: 'POST',
                body: JSON.stringify({
                    name: name, 
                    description: description,
                    price: price, 
                    categoryId: category, 
                    quantity: quantity}),
                headers: {'Content-Type': 'application/json'}
            });
            const data = await response.json();
            console.log(data);
            setName('');
            setDescription('');
            setPrice(0);
            setCategory('none');
            setQuantity(0);
        }    
    };

    return <Fragment>
            <form className="col-9" onSubmit={onSubmitHandler}>
                <div>
                    <label htmlFor="productName" className="form-label"><b>Product Name</b></label>
                    <input 
                        type="text" 
                        name="productName" 
                        id="productName" 
                        className="form-control" 
                        value={name}
                        onChange={onNameHandler} />
                </div>
                <div>
                    <label htmlFor="price" className="form-label"><b>Price</b></label>
                    <input 
                        type="number" 
                        min='0' 
                        step="0.01" 
                        name="productName" 
                        id="productName" 
                        className="form-control"
                        value={price}
                        onChange={onPriceHandler} />
                </div>
                <div>
                    <label htmlFor="description" className="form-label"><b>Product Description</b></label>
                    <textarea 
                        type="text" 
                        name="description" 
                        id="description" 
                        className="form-control" 
                        row='6'
                        value={description}
                        onChange={onDescriptionHandler} />
                </div>
                <div>
                    <label htmlFor="category" className="form-label"><b>Category</b></label>
                    <DropDown 
                        className="form-control" 
                        name="category" 
                        id="category" 
                        url='http://localhost:5284/category' 
                        value={category}
                        onSelect={onSelectCategoryHandler} />
                </div>
                <div>
                    <label htmlFor="quantity" className="form-label"><b>Initial Quantity</b></label>
                    <input 
                        type="number" 
                        min='0' 
                        step="1" 
                        name="quantity" 
                        id="quantity" 
                        className="form-control"
                        value={quantity}
                        onChange={onQuantityHandler} />
                </div>
                <button className="btn btn-primary">Submit</button>
            </form>
        </Fragment>
}

export default AddProduct;