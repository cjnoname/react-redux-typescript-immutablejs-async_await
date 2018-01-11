import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { Field, reduxForm } from 'redux-form'
import { ApplicationState }  from '../../store';
import { OAuthState } from './models';
import { actionCreators } from './actions';
import OAuthForm from './views/OAuthForm';
import { OAuthRequest } from './models';

// At runtime, Redux will merge together...
type OAuthProps =
    OAuthState        // ... state we've requested from the Redux store
    & typeof actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{}>; // ... plus incoming routing parameters

class OAuth extends React.Component<OAuthProps, {}> {

    componentWillMount() {
        // This method runs when the component is first added to the page
        // let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        // if(this.props.sample != null) {
        // this.props.saveData();
        // }
    }

    componentWillReceiveProps(nextProps: OAuthProps) {
        // This method runs when incoming props (e.g., route params) change
        // let startDateIndex = parseInt(nextProps.match.params.startDateIndex) || 0;
        // this.props.requestSample();
    }

    submit = (values: OAuthRequest) => {
        this.props.saveData(values);
    }

    public render() {
        return (
            <div>
                <OAuthForm onSubmit={this.submit} />
            </div>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.oAuth.toObject(), // Selects which state properties are merged into the component's props
    actionCreators                 // Selects which action creators are merged into the component's props
)(OAuth as any) as any;
