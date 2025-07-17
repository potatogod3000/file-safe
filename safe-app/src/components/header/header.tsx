import './header.scss';

export default function Header() {
    return <>
        <div className="app-header">
            <div className="header-logo-area">
                <img src="file_safe_icon.png" alt="File Safe" className="header-logo" title="File Safe - Home"/>
            </div>

            <div className="search-area">
                <input type="search" className="search-bar" placeholder="Search in File Safe..."/>
                <button type="button" className="search-button" title="Search">
                    <i className="bi bi-search"></i>
                </button>
            </div>

            <div className="actions-area">
                <div>
                    <i className="bi bi-cloud-plus-fill" title="Upload File or Folder"></i>
                </div>
                <div>
                    <i className="bi bi-brightness-high-fill" title="Select Theme"></i>
                </div>
            </div>
        </div>
    </>
}