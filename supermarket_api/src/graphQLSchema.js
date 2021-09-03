import merge from 'lodash.merge';
import GraphQLJSON from 'graphql-type-json';
import { makeExecutableSchema } from 'graphql-tools';

import { mergeSchemas } from './utilities';

import {
	categoryMutations,
	categoryQueries,
	categoryTypeDef
} from './supermarket/categories/typeDefs';

import { sampleMutations, sampleQueries, sampleTypeDef} from './supermarket/sample/typeDefs';

import categoryResolvers from './supermarket/categories/resolvers';
import sampleResolvers from './supermarket/sample/resolvers';

// merge the typeDefs
const mergedTypeDefs = mergeSchemas(
	[
		'scalar JSON',
		categoryTypeDef,
		sampleTypeDef
	],
	[
		categoryQueries,
		sampleQueries
	],
	[
		categoryMutations,
		sampleMutations
	]
);

// Generate the schema object from your types definition.
export default makeExecutableSchema({
	typeDefs: mergedTypeDefs,
	resolvers: merge(
		{ JSON: GraphQLJSON }, // allows scalar JSON
		categoryResolvers,
		sampleResolvers
	)
});
