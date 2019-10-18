import React from 'react';
import './App.css';
import { ApolloProvider } from 'react-apollo';
import { Provider } from 'react-redux';
import { store } from './app/store';
import client from './app/shared/apollo-client/ApolloClient';
import AdminLayout from './app/layouts/Admin/Admin';

const App: React.FC = () => {
  return (
    <>
      <Provider store={store}>
        <ApolloProvider client={client}>
          <AdminLayout />
        </ApolloProvider>
      </Provider>
    </>
  );
}

export default App;
