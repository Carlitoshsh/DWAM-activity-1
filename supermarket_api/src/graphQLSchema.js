import merge from 'lodash.merge';
import GraphQLJSON from 'graphql-type-json';
import { makeExecutableSchema } from 'graphql-tools';

import { mergeSchemas } from './utilities';

import {
	categoryMutations,
	categoryQueries,
	categoryTypeDef
} from './supermarket/categories/typeDefs';

import { supplierMutations, supplierQueries, supplierTypeDef} from './supermarket/suppliers/typeDefs';

import { orqMutations } from './supermarket/orquestation/typeDefsAux';

import categoryResolvers from './supermarket/categories/resolvers';
import supplierResolvers from './supermarket/suppliers/resolvers';
import orqResolvers from './supermarket/orquestation/resolvers';

// merge the typeDefs
const mergedTypeDefs = mergeSchemas(
	[
		'scalar JSON',
		categoryTypeDef,
		supplierTypeDef
	],
	[
		categoryQueries,
		supplierQueries
	],
	[
		categoryMutations,
		supplierMutations,
		orqMutations
	]
);

// Generate the schema object from your types definition.
export default makeExecutableSchema({
	typeDefs: mergedTypeDefs,
	resolvers: merge(
		{ JSON: GraphQLJSON }, // allows scalar JSON
		categoryResolvers,
		supplierResolvers,
		orqResolvers
	)
});
