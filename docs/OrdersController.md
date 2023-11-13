# Orders Controller Reference

## Introduction
This document outlines the usage of the Toppings Controller, which can be used to get and submit pizza orders

## Endpoints


### Get Orders List
- **URL:** `/api/orders`
- **Method:** `GET`
- **Request Parameters:** `-`
- **Response Type:** 
    ```javasript
    [
        {
            "id": int,
            "pizza": {
                "id": int,
                "name": string,
                "description: string
            },
            "price": decimal,
            "pizzaSize": PizzaSize,
            "orderToppings: [
                {
                    "id": int,
                    "name": string
                }
            ]

        }
    ]

    enum PizzaSize:
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    ```
- **Sample Request:** `GET /api/orders`
- **Sample Response:** 
    ```json
    [
        {
            "id": 1,
            "pizza": {
                "id": 2,
                "name": "Capricciosa",
                "description": "Italian tomato sauce, ham, mushrooms, olives, cheese sauce, basil"
            },
            "price": 14.40,
            "pizzaSize": 3,
            "orderToppings": [
                {
                    "id": 2,
                    "name": "Pickled bulbs"
                },
                {
                    "id": 8,
                    "name": "Jalapeño Pepper"
                },
                {
                    "id": 9,
                    "name": "Tomatoes"
                },
                {
                    "id": 10,
                    "name": "Bell pepper"
                }
            ]
        }
    ]
    ```

### Get Order
- **URL:** `/api/orders/{id}`
- **Method:** `GET`
- **Request Parameters:**
    - `PATH`:
        - `id` : int
- **Response Type:** 
    ```javasript
    {
        "id": int,
        "pizza": {
            "id": int,
            "name": string,
            "description: string
        },
        "price": decimal,
        "pizzaSize": PizzaSize,
        "orderToppings: [
            {
                "id": int,
                "name": string
            }
        ]

    }

    enum PizzaSize:
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    ```
- **Sample Request:** `GET /api/orders/1`
- **Sample Response:** 
    ```json
    {
        "id": 1,
        "pizza": {
            "id": 2,
            "name": "Capricciosa",
            "description": "Italian tomato sauce, ham, mushrooms, olives, cheese sauce, basil"
        },
        "price": 14.40,
        "pizzaSize": 3,
        "orderToppings": [
            {
                "id": 2,
                "name": "Pickled bulbs"
            },
            {
                "id": 8,
                "name": "Jalapeño Pepper"
            },
            {
                "id": 9,
                "name": "Tomatoes"
            },
            {
                "id": 10,
                "name": "Bell pepper"
            }
        ]
    }
    ```


### Add Order
- **URL:** `/api/orders`
- **Method:** `POST`
- **Request Parameters:**
    - `body:`
        ```javascript
        {
            "PizzaId": int,
            "PizzaSize": PizzaSize,
            "ToppingIds": int[]
        }

        enum PizzaSize
        {
            Small = 1,
            Medium = 2,
            Large = 3
        }
        ```
- **Response Type:** 
    ```javasript
    {
        "id": int,
        "pizza": {
            "id": int,
            "name": string,
            "description: string
        },
        "price": decimal,
        "pizzaSize": PizzaSize,
        "orderToppings: [
            {
                "id": int,
                "name": string
            }
        ]

    }

    enum PizzaSize:
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    ```
- **Sample Request:** `POST /api/orders`
    - `body:`
        ```json
        {
            "PizzaId": 1,
            "PizzaSize": 2,
            "ToppingIds": [1,3,4]
        }
        ```
- **Sample Response:** 
    ```json
    {
        "id": 1,
        "pizza": {
            "id": 1,
            "name": "Brooklyn",
            "description": "Italian tomato sauce, chicken, ham, salami, smoked beef, peppers, pepperoni peppers, cheese stew, basil"
        },
        "price": 13.00,
        "pizzaSize": 2,
        "orderToppings": [
            {
                "id": 1,
                "name": "Mozzarella"
            },
            {
                "id": 3,
                "name": "Pickled cucumbers"
            },
            {
                "id": 4,
                "name": "Pineapple"
            }
        ]
    }
    ```


### Calculate Price
- **URL:** `/api/orders/price`
- **Method:** `POST`
- **Request Parameters:**
    - `body:`
        ```javascript
        {
            "PizzaId": int,
            "PizzaSize": PizzaSize,
            "ToppingIds": int[]
        }

        enum PizzaSize
        {
            Small = 1,
            Medium = 2,
            Large = 3
        }
        ```
- **Response Type:** `decimal`
- **Sample Request:** `POST /api/orders/price`
    - `body:`
        ```json
        {
            "PizzaId": 1,
            "PizzaSize": 2,
            "ToppingIds": [1,3,4]
        }
        ```
- **Sample Response:** `13.00`
    