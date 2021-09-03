export const sampleTypeDef = `
    type Sample {
        id: String!
        date: String!
        summary: String!
        temperatureC: Int!
        temperatureF: Int!
    }
    input SampleInput{
        id: String!
        summary: String!
    }
`

export const sampleQueries = `
    allSamples: [Sample]!
    sampleById(id: Int!): Sample!
`

export const sampleMutations = `
    createSample(sample: SampleInput!): Sample!
    updateSample(id: Int!, sample: SampleInput!): Sample!
    deleteSample(id: Int!): Int
`