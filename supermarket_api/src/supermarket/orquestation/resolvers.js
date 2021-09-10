import resolverCategory from '../categories/resolvers';
import resolverSupplier from '../suppliers/resolvers';

const resolvers = {
	Query: {
	},
	Mutation: {
		// recibe dato de entrada
		countVowels: async (_, { id }) => {
			// consume microservicio1
			const response = await resolverCategory.Query.categoryById(_, { id });
			let demoEntity = {
				category : response.description
			};
			// consume microservicio2 con salida de microservicio1
			let demoResponse = await resolverSupplier.Mutation.countVowelsMS2(_, { demoEntity });
			// retorna respuesta microservicio2
			return demoResponse
		},
	}
};

export default resolvers;
