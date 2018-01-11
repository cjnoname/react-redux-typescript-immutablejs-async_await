import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../../store';
import { SampleState } from './models';
import { actionCreators } from './actions';

// At runtime, Redux will merge together...
type ClientViewProps =
    SampleState        // ... state we've requested from the Redux store
    & typeof actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{}>; // ... plus incoming routing parameters

class ClientView extends React.Component<ClientViewProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        // let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        this.props.requestSample();
    }

    componentWillReceiveProps(nextProps: ClientViewProps) {
        // This method runs when incoming props (e.g., route params) change
        // let startDateIndex = parseInt(nextProps.match.params.startDateIndex) || 0;
        // this.props.requestSample();
    }

    public render() {
        return <div>
            <h1>Sample data</h1>
            <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
            { this.renderForecastsTable() }
            { this.renderPagination() }
        </div>;
    }

    private renderForecastsTable() {
        const { sample, isLoading } = this.props;
        return isLoading
                ? <span>Loading...</span>
                : <table className='table'>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp. (C)</th>
                            <th>Temp. (F)</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                    <tr key="aaa">
                        <td>{ sample.clientId }</td>
                        <td>{ sample.token }</td>
                        <td>{ sample.client!.clientId}</td>
                    </tr>
                    </tbody>
                </table>;
    }

    private renderPagination() {
        // let prevStartDateIndex = (this.props.startDateIndex || 0) - 5;
        // let nextStartDateIndex = (this.props.startDateIndex || 0) + 5;

        return <p className='clearfix text-center'>
            {/* <Link className='btn btn-default pull-left' to={ `/fetchdata/${ prevStartDateIndex }` }>Previous</Link>
            <Link className='btn btn-default pull-right' to={ `/fetchdata/${ nextStartDateIndex }` }>Next</Link> */}
            { this.props.isLoading ? <span>Loading...</span> : [] }
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.clientView.toObject(), // Selects which state properties are merged into the component's props
    actionCreators                 // Selects which action creators are merged into the component's props
)(ClientView as any) as any;
