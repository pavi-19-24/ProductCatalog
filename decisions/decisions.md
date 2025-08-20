# Design Decisions

## 1. Database Design
- Used EAV (Entity-Attribute-Value) for dynamic product attributes.
- Normalized tables to reduce redundancy.
- Allows adding new categories and attributes without altering schema.

## 2. Class Design
- Classes: Category, Attribute, Product.
- ProductService handles CRUD operations for products.
- Flexible design: can extend for new categories.

## 3. Scalability
- Adding new categories only requires adding rows in Categories and Attributes.
- ProductAttributes table stores dynamic values, so schema remains unchanged for future products.
