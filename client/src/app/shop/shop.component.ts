import { ShopService } from './shop.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected = 0;
  typeIdSelected = 0;


  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    console.log(this.brandIdSelected);
    return this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe(response => {
      this.products = response.data;
    },
      errors => {
        console.log(errors);
      });
  }

  getBrands() {
    return this.shopService.getBrands().subscribe(response => {
      // this.brands = response;
      this.brands = [{ id: 0, name: 'All' }, ...response];
    },
      errors => {
        console.log(errors);
      });
  }

  getTypes() {
    return this.shopService.getTypes().subscribe(response => {
      // this.types = response;
      this.types = [{ id: 0, name: 'All' }, ...response];
    },
      errors => {
        console.log(errors);
      });
  }

  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

}
