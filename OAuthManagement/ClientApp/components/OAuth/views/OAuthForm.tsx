import * as React from 'react';
import { Field, reduxForm } from 'redux-form'

let OAuthForm = (props: any) => {
  const { handleSubmit } = props
  return (
    <form onSubmit={handleSubmit}>
      <div>
          <label htmlFor="clientId">Client ID</label>
          <Field name="clientId" component="input" type="text" />
      </div>
      <div>
          <label htmlFor="clientSecret">Client Secret</label>
          <Field name="clientSecret" component="input" type="text" />
      </div>
      <div>
          <label htmlFor="clientName">Client Name</label>
          <Field name="clientName" component="input" type="text" />
      </div>
      <div>
          <label htmlFor="placeCode">Place Code</label>
          <Field name="placeCode" component="input" type="text" />
      </div>
      <div>
          <label htmlFor="chainCode">Chain Code</label>
          <Field name="chainCode" component="input" type="text" />
      </div>
      <button type="submit">Submit</button>
    </form>
  )
}

export default reduxForm({
    form: 'oauth'
})(OAuthForm) as any;