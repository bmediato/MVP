export interface Dish {
  name: string;
  description: string;
  price: string;
  foodType: number;
  image: string;
}

export interface Restaurant {
  id: string;
  name: string;
  category: number;
  description: string;
  address: string;
  phoneNumber: string;
  logo: string;
  banner: string;
  dishes: Dish[];
}
