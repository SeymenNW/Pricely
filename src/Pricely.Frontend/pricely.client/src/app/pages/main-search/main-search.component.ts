import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-main-search',
  imports: [CommonModule, ButtonModule],
  templateUrl: './main-search.component.html',
  styleUrl: './main-search.component.scss'
})
export class MainSearchComponent {
  featuredProducts = [
    {
      name: 'AMD Radeon RX 9070 XT',
      image: 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTGppXwviNChqMOKgWOXWLoMjcYAIDDEzKGbukzWS6BFNVVaJBsDZ4EXNa3_GcZeQkIEoyBvWc3NjHM71DHbDvJfJjKZEJThQ0Uq4iHROkSjXOoEO8XAargtg',
      price: 6290,
      reviews: 124,
      discount: 12
    },
    {
      name: 'iPhone 15 Pro 128GB Sort',
      image: 'https://via.placeholder.com/200?text=iPhone+15',
      price: 8999,
      reviews: 124,
      discount: 12
    },
    {
      name: 'Samsung Galaxy S23 Ultra 256GB',
      image: 'https://via.placeholder.com/200?text=Galaxy+S23',
      price: 7999,
      reviews: 89,
      discount: 8
    },
    {
      name: 'Sony WH-1000XM5 Trådløse hovedtelefoner',
      image: 'https://via.placeholder.com/200?text=Sony+Headphones',
      price: 2499,
      reviews: 256,
      discount: 15
    },
    {
      name: 'PlayStation 5 Digital Edition',
      image: 'https://via.placeholder.com/200?text=PS5',
      price: 3499,
      reviews: 312,
      discount: 10
    }
  ];
}
