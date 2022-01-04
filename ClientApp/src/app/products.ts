export interface Product {
    id: number;
    owner: string;
    name: string;
    totalPrice: number;
    pricePerMonth: number;
    acqPrice: number;
  }
  
  export const products = [
    {
        id: 1,
        owner: 'Apple',
        name: 'iPhone 13',
        totalPrice: 829,
        pricePerMonth: 34,
        acqPrice: 13
    },
    {
        id: 2,
        owner: 'Apple',
        name: 'iPhone 12',
        totalPrice: 729,
        pricePerMonth: 29,
        acqPrice: 33
    },
    {
        id: 3,
        owner: 'Samsung',
        name: 'Galaxy Z Fold3 5G',
        totalPrice: 1799,
        pricePerMonth: 74,
        acqPrice: 23
    }
  ];
  
  
  /*
  Copyright Google LLC. All Rights Reserved.
  Use of this source code is governed by an MIT-style license that
  can be found in the LICENSE file at https://angular.io/license
  */