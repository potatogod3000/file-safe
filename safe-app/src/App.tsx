import './App.scss'
import Header from "./components/header/header.tsx";
import Footer from "./components/footer/footer.tsx";

export default function App() {
  return (
    <>
        <div className="main-app">
            <section>
                <Header />
            </section>

            <section></section>

            <section>
                <Footer />
            </section>
        </div>
    </>
  )
}
