export const supplierTypeDef = `
    type Supplier {
        id: Int!
        name: String!
        identificationId: String!
        phone: String!
        address: String!
    }
    type DemoResponse {
        totalVowels: Int!
    }
    input DemoEntity {
        category: String!
    }
    input SupplierInput{
        id: Int!
        name: String!
        identificationId: String!
        phone: String!
        address: String!
    }
`

export const supplierQueries = `
    allSuppliers: [Supplier]!
    supplierById(id: Int!): Supplier!
`

export const supplierMutations = `
    createSupplier(supplier: SupplierInput!): Supplier!
    updateSupplier(id: Int!, supplier: SupplierInput!): Supplier!
    deleteSupplier(id: Int!): Int
    countVowelsMS2(demoEntity: DemoEntity!): DemoResponse!
`