import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Product } from '../models/product.model';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'] // ✅ Re-added with new styles
})
export class ProductsComponent {
  isAdmin = true;

  searchText = '';
  selectedCategory = '';
  sortBy = '';

  products: Product[] = [
    {
      id: 1,
      name: 'iPhone 15',
      description: 'Apple smartphone',
      price: 56999,
      category: 'Smartphones',
      stock: 20,
      imageUrl: 'https://m.media-amazon.com/images/I/71d7rfSl0wL.jpg',
      rating: 4.5,
      reviews: 10
    },
    {
      id: 2,
      name: 'Samsung Galaxy S23',
      description: 'Samsung flagship phone',
      price: 56900,
      category: 'Smartphones',
      stock: 15,
      imageUrl: 'https://m.media-amazon.com/images/I/610Q2I5Or8L.jpg',
      rating: 4.2,
      reviews: 8
    },
    {
    
      id: 3,
      name: 'Samsung Galaxy F62',
      description: 'Samsung flagship phone',
      price: 36900,
      category: 'Smartphones',
      stock: 15,
      imageUrl: 'https://www.gizmochina.com/wp-content/uploads/2021/02/f62.jpg',
      rating: 4.7,
      reviews: 6
    },
    {
    
      id: 4,
      name: 'Dell Inspiron 15',
      description: '15.6-inch FHD Laptop, 11th Gen Intel i5, 8GB RAM, 512GB SSD',
      price: 58900,
      category: 'Laptop',
      stock: 15,
      imageUrl: 'https://m.media-amazon.com/images/I/817hATbspxL.jpg',
      rating: 4.7,
      reviews: 6
    },
    {
    
      id: 5,
      name: 'HP Pavilion x360',
      description: '14-inch Touchscreen 2-in-1 Laptop, i5 12th Gen, 16GB RAM, 512GB SSD',
      price: 68900,
      category: 'Laptop',
      stock: 15,
      imageUrl: 'https://uniquec.com/wp-content/uploads/x360-435.jpg',
      rating: 4.7,
      reviews: 6
    },
    {
    
      id: 6,
      name: 'Lenovo IdeaPad Slim 5',
      description: '15.6-inch FHD Laptop, 11th Gen Intel i5, 8GB RAM, 512GB SSD',
      price: 87900,
      category: 'Laptop',
      stock: 15,
      imageUrl: 'https://m.media-amazon.com/images/I/817hATbspxL.jpg',
      rating: 4.7,
      reviews: 6
    },


    // ➕ Add more if needed
  ];

  newProduct: Product = {
    id: 0,
    name: '',
    description: '',
    price: 0,
    category: '',
    stock: 0,
    imageUrl: '',
    rating: 0,
    reviews: 0
  };

  get filteredProducts(): Product[] {
    let filtered = this.products;

    if (this.searchText) {
      filtered = filtered.filter(p => p.name.toLowerCase().includes(this.searchText.toLowerCase()));
    }

    if (this.selectedCategory) {
      filtered = filtered.filter(p => p.category === this.selectedCategory);
    }

    if (this.sortBy === 'price') {
      filtered = filtered.sort((a, b) => a.price - b.price);
    } else if (this.sortBy === 'rating') {
      filtered = filtered.sort((a, b) => b.rating - a.rating);
    }

    return filtered;
  }

  applyFilters() {}

  addProduct() {
    const newId = this.products.length + 1;
    const productToAdd = { ...this.newProduct, id: newId };
    this.products.push(productToAdd);

    this.newProduct = {
      id: 0,
      name: '',
      description: '',
      price: 0,
      category: '',
      stock: 0,
      imageUrl: '',
      rating: 0,
      reviews: 0
    };
  }
}
