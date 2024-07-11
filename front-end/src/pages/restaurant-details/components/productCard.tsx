 import { Dish } from '../../../models/restaurant.model';
import './productsCard.css';
 
function ProductCard({ products }: { products: Dish[] }) {
  return (
    <div className="product-card-container">
      {products.map((product) => (
        <div className="product-card" key={product.description}>
          <img className='product-card-img' src={product.image} alt="" />
           <h1 className='product-card-title'>{product.name}</h1>
          <div>
            <p className='product-card-sub-title'>{product.description}</p>
            <p>{`R$ ${product.price}`}</p>
          </div>
        </div>
      ))}
    </div>
  );
}

 
export default ProductCard;
